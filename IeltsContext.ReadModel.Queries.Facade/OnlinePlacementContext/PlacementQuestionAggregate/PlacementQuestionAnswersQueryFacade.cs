using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementQuestionAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.OnlinePlacementContext.PlacementQuestionAggregate
{
    public class PlacementQuestionAnswersQueryFacade : IPlacementQuestionAnswersQueryFacade
    {
        public PlacementQuestionAnswersQueryFacadeDto GetPlacementQuestionAnswers(Guid placementQuestionAnswersId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.PlacementQuestionAnswers.Where(a => a.IsDeleted == false && a.Id == placementQuestionAnswersId)
                            select new PlacementQuestionAnswersQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                OrderNo = i.OrderNo,
                                IsCorrect = (bool)i.IsCorrect,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                PlacementQuestionId=i.PlacementQuestionId
                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<PlacementQuestionAnswersQueryFacadeDto> GetPlacementQuestionAnswersList(ref DataTableAjaxPostModel filters, Guid id)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                    var data = (from i in context.PlacementQuestionAnswers.Where(a => a.PlacementQuestionId == id && a.IsDeleted == false)
                            select new PlacementQuestionAnswersQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                OrderNo = i.OrderNo,
                                IsCorrect = (bool)i.IsCorrect,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                PlacementQuestionId = i.PlacementQuestionId
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
    }
}
