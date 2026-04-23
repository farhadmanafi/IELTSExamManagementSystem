using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserAnswerAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserAnswerAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.OnlinePlacementContext.PlacementUserAnswerAggregate
{
    public class PlacementUserAnswerQueryFacade : IPlacementUserAnswerQueryFacade
    {
        public PlacementUserAnswerQueryFacadeDto GetPlacementUserAnswer(Guid placementUserAnswerId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.PlacementUserAnswers.Where(a => a.Id == placementUserAnswerId)
                            select new PlacementUserAnswerQueryFacadeDto()
                            {
                                Id = i.Id,
                                IeltsExamId = i.IeltsExamId,
                                PlacementUserScoreId = i.PlacementUserScoreId,
                                QuestionId = i.QuestionId,
                                AnswerId = i.AnswerId,
                                AnswerText = i.AnswerText,
                                CustomerId = i.CustomerId
                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<PlacementUserAnswerQueryFacadeDto> GetPlacementUserAnswerList(ref DataTableAjaxPostModel filters)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                    var data = (from i in context.PlacementUserAnswers
                            select new PlacementUserAnswerQueryFacadeDto()
                            {
                                Id = i.Id,
                                IeltsExamId = i.IeltsExamId,
                                PlacementUserScoreId = i.PlacementUserScoreId,
                                QuestionId = i.QuestionId,
                                AnswerId = i.AnswerId,
                                AnswerText = i.AnswerText,
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

        public IEnumerable<PlacementUserAnswerQueryFacadeDto> GetPlacementUserAnswerByPlacementUserScoreIdList(ref DataTableAjaxPostModel filters, Guid placementUserScoreId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                    var data = (from i in context.PlacementUserAnswers.Where(a=>a.PlacementUserScoreId == placementUserScoreId)
                                join answer in context.PlacementQuestionAnswers on i.AnswerId equals answer.Id into answer
                                from x in answer.DefaultIfEmpty()
                                //from answer in context.PlacementQuestionAnswers.Where(x => x.Id == i.AnswerId)
                                let question = (from q in context.PlacementQuestions where i.QuestionId == q.Id select q).FirstOrDefault()
                                //let answer = (from a in context.PlacementQuestionAnswers where i.AnswerId == a.Id select a).FirstOrDefault()                                
                                select new PlacementUserAnswerQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    IeltsExamId = i.IeltsExamId,
                                    PlacementUserScoreId = i.PlacementUserScoreId,
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

        public IEnumerable<PlacementUserAnswerQueryFacadeDto> GetPlacementUserAnswerByPlacementUserScoreIdListUserPanel(Guid placementUserScoreId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {

                    var data = (from i in context.PlacementUserAnswers.Where(a=>a.PlacementUserScoreId == placementUserScoreId)
                                join answer in context.PlacementQuestionAnswers on i.AnswerId equals answer.Id into answer
                                from x in answer.DefaultIfEmpty()
                                //from answer in context.PlacementQuestionAnswers.Where(x => x.Id == i.AnswerId)
                                let question = (from q in context.PlacementQuestions where i.QuestionId == q.Id select q).FirstOrDefault()
                                //let answer = (from a in context.PlacementQuestionAnswers where i.AnswerId == a.Id select a).FirstOrDefault()                                
                                select new PlacementUserAnswerQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    IeltsExamId = i.IeltsExamId,
                                    PlacementUserScoreId = i.PlacementUserScoreId,
                                    QuestionId = i.QuestionId,
                                    QuestionTitle = question.Title,
                                    AnswerId = i.AnswerId,
                                    AnswerTitle = (x == null ? null : x.Title), // answer.Title,
                                    IsCorrectAnswer = (x == null ? null : x.IsCorrect), // answer.IsCorrect,
                                    AnswerText = i.AnswerText,
                                    //IsCorrectAnswer = answer == null ? 2 : (answer.IsCorrect == true ? 1 : 0),
                                    CustomerId = i.CustomerId
                                });

                    return data.ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
