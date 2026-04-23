using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingExamAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.WritingContext.WritingExamAggregate
{
    public class WritingExamQueryFacade : IWritingExamQueryFacade
    {
        public IEnumerable<WritingExamQueryFacadeDto> GetWritingExamByFilteringList(ref DataTableAjaxPostModel filters, Guid examId)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.WritingExams.Where(a => a.IeltsExamId == examId && a.IsDeleted == false)
                                select new WritingExamQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    IeltsExamId = i.IeltsExamId,
                                    Description = i.Description,
                                    Title = i.Title,
                                    TimerMinuties = i.TimerMinuties,
                                    IsActive = i.IsActive,
                                    IsDeleted = i.IsDeleted
                                });

                    var Result = data.Where(v =>
                                (titleSerach == null ||
                                (titleSerach != null && (v.Title.Contains(titleSerach.ToString()) |
                                                        v.Description.Contains(titleSerach.ToString()))
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

        public WritingExamQueryFacadeDto GetWritingExamForUserPanel(Guid id)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.WritingExams.Where(a => a.Id == id && a.IsActive == true && a.IsDeleted == false)
                                select new WritingExamQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    IeltsExamId = i.IeltsExamId,
                                    Description = i.Description,
                                    Title = i.Title,
                                    TimerMinuties = i.TimerMinuties,
                                    IsActive = i.IsActive,
                                    IsDeleted = i.IsDeleted
                                });

                    return data.FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public WritingExamQueryFacadeDto GetWritingExamById(Guid writingExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.WritingExams.Where(a => a.IsActive == true && a.IsDeleted == false && a.Id == writingExamId)
                            select new WritingExamQueryFacadeDto()
                            {
                                Id = i.Id,
                                IeltsExamId = i.IeltsExamId,
                                Title = i.Title,
                                Description = i.Description,
                                TimerMinuties=i.TimerMinuties,
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

        public int GetWritingExamCount(Guid id)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return  context.WritingExams.Where(a =>a.IeltsExamId==id && a.IsActive == true).Count();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<WritingExamQueryFacadeDto> GetWritingExamList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.WritingExams.Where(a => a.IsActive == true && a.IsDeleted == false )
                            select new WritingExamQueryFacadeDto()
                            {
                                Id = i.Id,
                                IeltsExamId = i.IeltsExamId,
                                Title = i.Title,
                                Description = i.Description,
                                TimerMinuties = i.TimerMinuties,
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

        public Guid GetIeltsExamByWritingExamId(Guid writingExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return context.WritingExams.FirstOrDefault(a => a.Id == writingExamId).IeltsExamId;
                }

            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
