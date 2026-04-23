using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingQuestionAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.ReadingContext.ReadingQuestionAggregate
{
    public class ReadingQuestionAnswersQueryFacade : IReadingQuestionAnswersQueryFacade
    {
        public IEnumerable<ReadingQuestionAnswersQueryFacadeDto> GetReadingQuestionAnswerListForGridView(ref DataTableAjaxPostModel filters, Guid id)
        {
            try
            {
                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.ReadingQuestionAnswers.Where(a => a.ReadingQuestionId == id && a.IsDeleted == false)
                            select new ReadingQuestionAnswersQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                OrderNo = i.OrderNo,
                                IsCorrect = (bool)i.IsCorrect,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ReadingQuestionId = i.ReadingQuestionId
                            });

                    var Result = data.Where(v =>
                                (titleSerach_ByName == null ||
                                (titleSerach_ByName != null && (v.Title.Contains(titleSerach_ByName.ToString()))))).AsQueryable();

                    filters.filteredResultsCount = Result.Count();

                    var sort = (filters.order != null ? filters.columns[filters.order[0].column].data : "") + " " + (filters.order != null ? filters.order[0].dir.ToLower() : "");

                    Result = Result.OrderBy(sort).Skip(filters.start).Take(filters.length);
                    return Result.ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public ReadingQuestionAnswersQueryFacadeDto GetReadingQuestionAnswers(Guid readingQuestionAnswersId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ReadingQuestionAnswers.Where(a => a.Id == readingQuestionAnswersId)
                            select new ReadingQuestionAnswersQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                OrderNo = i.OrderNo,
                                IsCorrect = (bool)i.IsCorrect,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ReadingQuestionId=i.ReadingQuestionId
                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<ReadingQuestionAnswersQueryFacadeDto> GetReadingQuestionAnswersList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ReadingQuestionAnswers.Where(a => a.IsActive == true &&
                            a.IsDeleted == false)
                            select new ReadingQuestionAnswersQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                OrderNo = i.OrderNo,
                                IsCorrect = (bool)i.IsCorrect,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ReadingQuestionId = i.ReadingQuestionId
                            }).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
