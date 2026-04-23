using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.SpeakingContext.SpeakingExamAggregate
{
    public class SpeakingExamQueryFacade : ISpeakingExamQueryFacade
    {
        public SpeakingExamQueryFacadeDto GetSpeakingExamById(Guid speakingExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.SpeakingExams.Where(a => a.IsDeleted == false && a.Id == speakingExamId)
                            select new SpeakingExamQueryFacadeDto()
                            {
                                Id = i.Id,
                                IeltsExamId = i.IeltsExamId,
                                Title = i.Title,
                                Description = i.Description,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted
                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<SpeakingExamQueryFacadeDto> GetSpeakingExamByFilteringList(ref DataTableAjaxPostModel filters, Guid ieltsExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                    var data = (from i in context.SpeakingExams.Where(a => a.IeltsExamId == ieltsExamId && a.IsDeleted == false)
                                select new SpeakingExamQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    IeltsExamId = i.IeltsExamId,
                                    Title = i.Title,
                                    Description = i.Description,
                                    IsActive = i.IsActive,
                                    IsDeleted = i.IsDeleted
                                });

                    var Result = data.Where(v =>
                                (titleSerach == null ||
                                (titleSerach != null && (v.Title.Contains(titleSerach.ToString()))
                                                                      ))).AsQueryable();

                    filters.filteredResultsCount = Result.Count();

                    var sort = (filters.order != null ? filters.columns[filters.order[0].column].data : "") + " " + (filters.order != null ? filters.order[0].dir.ToLower() : "");

                    Result = Result.OrderBy(sort).Skip(filters.start).Take(filters.length);

                    var ResultFinal = Result.ToList();
                    return ResultFinal.ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<SpeakingExamQueryFacadeDto> GetSpeakingExamList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.SpeakingExams.Where(a =>a.IsDeleted == false)
                            select new SpeakingExamQueryFacadeDto()
                            {
                                Id = i.Id,
                                IeltsExamId = i.IeltsExamId,
                                Title = i.Title,
                                Description = i.Description,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted
                            }).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public int GetSpeakingExamCount(Guid id)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return  context.SpeakingExams.Where(a =>a.IeltsExamId==id).Count();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public SpeakingExamQueryFacadeDto GetSpeakingExamForUserPanel(Guid id)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.SpeakingExams.Where(a => a.IsDeleted == false && a.Id == id)
                            select new SpeakingExamQueryFacadeDto()
                            {
                                Id = i.Id,
                                IeltsExamId = i.IeltsExamId,
                                Title = i.Title,
                                Description = i.Description,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted
                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public Guid GetIeltsExamBySpeakingExamId(Guid speakingExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return context.SpeakingExams.FirstOrDefault(a => a.Id == speakingExamId).IeltsExamId;
                }

            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
