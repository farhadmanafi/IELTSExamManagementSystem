using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingUserAnswerAggregate;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingUserAnswerAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.ReadingContext.ReadingUserAnswerAggregate
{
    public class ReadingUserAnswerQueryFacade : IReadingUserAnswerQueryFacade
    {
        public IEnumerable<ReadingUserAnswerQueryFacadeDto> GetReadingExamUserAnswerListByIeltsExamId(ref DataTableAjaxPostModel filters, Guid? readingExamId, Guid? ieltsExamParticipantsId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                    var data = (from i in context.ReadingUserAnswers.Where(a => a.ReadingExamId == readingExamId && a.IeltsExamParticipantId == ieltsExamParticipantsId)
                                join answer in context.ReadingQuestionAnswers on i.AnswerId equals answer.Id into answer
                                from x in answer.DefaultIfEmpty()
                                    //from answer in context.PlacementQuestionAnswers.Where(x => x.Id == i.AnswerId)
                                let question = (from q in context.ReadingQuestions where i.QuestionId == q.Id select q).FirstOrDefault()
                                //let answer = (from a in context.PlacementQuestionAnswers where i.AnswerId == a.Id select a).FirstOrDefault()                                
                                select new ReadingUserAnswerQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    ReadingExamId = i.ReadingExamId,
                                    IeltsExamParticipantId = i.IeltsExamParticipantId,
                                    QuestionId = i.QuestionId,
                                    QuestionTitle = question.Title,
                                    AnswerId = i.AnswerId,
                                    AnswerTitle = (x == null ? null : x.Title), // answer.Title,
                                    IsCorrectAnswer = (x == null ? null : x.IsCorrect), // answer.IsCorrect,
                                    AnswerText = i.AnswerText,
                                    //IsCorrectAnswer = answer == null ? 2 : (answer.IsCorrect == true ? 1 : 0),
                                    CustomerId = i.CustomerId
                                });

                    var Result = data.Where(v =>
                                (titleSerach_ByName == null ||
                                (titleSerach_ByName != null && (v.AnswerText.Contains(titleSerach_ByName.ToString()))))).AsQueryable();

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

        public IEnumerable<ReadingUserAnswerQueryFacadeDto> GetReadingExamUserAnswerListUserPanel(ref DataTableAjaxPostModel filters, Guid readingExamId, Guid ieltsExamParticipantsId, Guid customerId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                    var data = (from i in context.ReadingUserAnswers.Where(a => a.ReadingExamId == readingExamId && a.IeltsExamParticipantId == ieltsExamParticipantsId && a.CustomerId == customerId)
                                join answer in context.ReadingQuestionAnswers on i.AnswerId equals answer.Id into answer
                                from x in answer.DefaultIfEmpty()
                                    //from answer in context.PlacementQuestionAnswers.Where(x => x.Id == i.AnswerId)
                                let question = (from q in context.ReadingQuestions where i.QuestionId == q.Id select q).FirstOrDefault()
                                //let answer = (from a in context.PlacementQuestionAnswers where i.AnswerId == a.Id select a).FirstOrDefault()                                
                                select new ReadingUserAnswerQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    ReadingExamId = i.ReadingExamId,
                                    IeltsExamParticipantId = i.IeltsExamParticipantId,
                                    QuestionId = i.QuestionId,
                                    QuestionTitle = question.Title,
                                    AnswerId = i.AnswerId,
                                    AnswerTitle = (x == null ? null : x.Title), // answer.Title,
                                    IsCorrectAnswer = (x == null ? null : x.IsCorrect), // answer.IsCorrect,
                                    AnswerText = i.AnswerText,
                                    //IsCorrectAnswer = answer == null ? 2 : (answer.IsCorrect == true ? 1 : 0),
                                    CustomerId = i.CustomerId
                                });

                    var Result = data.Where(v =>
                                (titleSerach_ByName == null ||
                                (titleSerach_ByName != null && (v.AnswerText.Contains(titleSerach_ByName.ToString()))))).AsQueryable();

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

        public ReadingUserAnswerQueryFacadeDto GetReadingUserAnswer(Guid readingUserAnswerId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ReadingUserAnswers.Where(a => a.IsActive == true && a.IsDeleted == false && a.Id == readingUserAnswerId)
                            select new ReadingUserAnswerQueryFacadeDto()
                            {
                                Id = i.Id,
                                ReadingExamId = i.ReadingExamId,
                                IeltsExamParticipantId = i.IeltsExamParticipantId,
                                QuestionId = i.QuestionId,
                                AnswerId = i.AnswerId,
                                AnswerText = i.AnswerText,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                CustomerId = i.CustomerId
                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<ReadingUserAnswerQueryFacadeDto> GetReadingUserAnswerList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ReadingUserAnswers.Where(a => a.IsActive == true && a.IsDeleted == false )
                            select new ReadingUserAnswerQueryFacadeDto()
                            {
                                Id = i.Id,
                                ReadingExamId = i.ReadingExamId,
                                IeltsExamParticipantId = i.IeltsExamParticipantId,
                                QuestionId = i.QuestionId,
                                AnswerId = i.AnswerId,
                                AnswerText = i.AnswerText,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                CustomerId = i.CustomerId
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
