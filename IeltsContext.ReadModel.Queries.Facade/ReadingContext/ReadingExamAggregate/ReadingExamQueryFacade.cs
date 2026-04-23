using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.ReadingContext.ReadingExamAggregate
{
    public class ReadingExamQueryFacade : IReadingExamQueryFacade
    {
        public ReadingExamQueryFacadeDto GetReadingExamById(Guid readingExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ReadingExams.Where(a => a.IsDeleted == false && a.Id == readingExamId)
                            select new ReadingExamQueryFacadeDto()
                            {
                                Id = i.Id,
                                IeltsExamId = i.IeltsExamId,
                                Title = i.Title,
                                Description = i.Description,
                                TimerMinuties = i.TimerMinuties,
                                IsActive = (bool)i.IsActive,
                                IsDeleted = (bool)i.IsDeleted
                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<ReadingExamQueryFacadeDto> GetReadingExamByFilteringList(ref DataTableAjaxPostModel filters, Guid examId)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.ReadingExams.Where(a => a.IeltsExamId == examId && a.IsDeleted == false)
                            select new ReadingExamQueryFacadeDto()
                            {
                                Id = i.Id,
                                IeltsExamId = i.IeltsExamId,
                                Title = i.Title,
                                Description = i.Description,
                                TimerMinuties = i.TimerMinuties,
                                IsActive = (bool)i.IsActive,
                                IsDeleted = (bool)i.IsDeleted
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

        public IEnumerable<ReadingExamQueryFacadeDto> GetReadingExamList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ReadingExams.Where(a => a.IsDeleted == false)
                            select new ReadingExamQueryFacadeDto()
                            {
                                Id = i.Id,
                                IeltsExamId = i.IeltsExamId,
                                Title = i.Title,
                                Description = i.Description,
                                TimerMinuties = i.TimerMinuties,
                                IsActive = (bool)i.IsActive,
                                IsDeleted = (bool)i.IsDeleted
                            }).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public int GetReadingExamCount(Guid id)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return context.ReadingExams.Where(a => a.IeltsExamId == id && a.IsActive == true).Count();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public ReadingExamQueryFacadeDto GetReadingExamForUserPanel(Guid id)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.ReadingExams.Where(a => a.Id == id && a.IsActive == true && a.IsDeleted == false)
                                select new ReadingExamQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    IeltsExamId = i.IeltsExamId,
                                    Description = i.Description,
                                    Title = i.Title,
                                    TimerMinuties = i.TimerMinuties,
                                    IsActive = (bool)i.IsActive,
                                    IsDeleted = (bool)i.IsDeleted
                                });

                    return data.FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public Guid GetIeltsExamByReadingExamId(Guid readingExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return context.ReadingExams.FirstOrDefault(a => a.Id == readingExamId).IeltsExamId;
                }

            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
