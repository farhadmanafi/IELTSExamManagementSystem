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
using Framework.Mapper;

namespace ExamContext.ReadModel.Queries.Facade.OnlinePlacementContext.PlacementQuestionAggregate
{
    public class PlacementQuestionQueryFacade : IPlacementQuestionQueryFacade
    {
        public PlacementQuestionQueryFacadeDto GetPlacementQuestion(Guid PlacementQuestionId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.PlacementQuestions.Where(a => a.IsDeleted == false && a.Id == PlacementQuestionId)
                            select new PlacementQuestionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                PlacementExamtId = i.PlacementExamtId,
                                OrderNo = i.OrderNo,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                PlacementQuestionTypeId = i.PlacementQuestionTypeId
                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<PlacementQuestionQueryFacadeDto> GetPlacementQuestionList(ref DataTableAjaxPostModel filters, Guid id)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                    var data = (from i in context.PlacementQuestions.Where(a => a.PlacementExamtId == id && a.IsDeleted == false)
                                let placementQuestionType = (from us in context.PlacementQuestionTypes where i.PlacementQuestionTypeId == us.Id select us).FirstOrDefault()
                                select new PlacementQuestionQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    Title = i.Title,
                                    Description = i.Description,
                                    OrderNo = i.OrderNo,
                                    IsActive = i.IsActive,
                                    PlacementExamtId = i.PlacementExamtId,
                                    IsDeleted = i.IsDeleted,
                                    PlacementQuestionTypeId = i.PlacementQuestionTypeId,
                                    PlacementQuestionTypeTitle = placementQuestionType.Title,
                                    PlacementQuestionTypeCodeName = placementQuestionType.CodeName,
                                });

                    var Result = data.Where(v =>
                                (titleSerach_ByName == null ||
                                (titleSerach_ByName != null && (v.Title.Contains(titleSerach_ByName.ToString()) ||
                                                                      v.Description.Contains(titleSerach_ByName.ToString()))
                                                                      ))).AsQueryable();

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

        public IEnumerable<PlacementQuestionQueryFacadeDto> GetPlacementQuestionByPlacementExamList(Guid placementExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.PlacementQuestions.Where(a => a.IsDeleted == false && a.PlacementExamtId == placementExamId)
                            let placementQuestionType = (from us in context.PlacementQuestionTypes where i.PlacementQuestionTypeId == us.Id select us).FirstOrDefault()
                            select new PlacementQuestionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                OrderNo = i.OrderNo,
                                PlacementExamtId = i.PlacementExamtId,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                PlacementQuestionTypeId = i.PlacementQuestionTypeId,
                                PlacementQuestionTypeTitle = placementQuestionType.Title,
                                PlacementQuestionTypeCodeName = placementQuestionType.CodeName,
                                PlacementQuestionAnswers = (List<PlacementQuestionAnswersQueryFacadeDto>)Mapper.Map<PlacementQuestionAnswer ,PlacementQuestionAnswersQueryFacadeDto>(i.PlacementQuestionAnswers)
                            }).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public IEnumerable<PlacementQuestionQueryFacadeDto> GetPlacementQuestionByPlacementExamUserPanelList(Guid placementExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.PlacementQuestions.Where(a => a.IsDeleted == false && a.PlacementExamtId == placementExamId)
                            let placementQuestionType = (from us in context.PlacementQuestionTypes where i.PlacementQuestionTypeId == us.Id select us).FirstOrDefault()
                            select new PlacementQuestionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                OrderNo = i.OrderNo,
                                PlacementExamtId = i.PlacementExamtId,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                PlacementQuestionTypeId = i.PlacementQuestionTypeId,
                                PlacementQuestionTypeTitle = placementQuestionType.Title,
                                PlacementQuestionTypeCodeName = placementQuestionType.CodeName,
                                PlacementQuestionAnswers = (List<PlacementQuestionAnswersQueryFacadeDto>)Mapper.Map<PlacementQuestionAnswer ,PlacementQuestionAnswersQueryFacadeDto>(i.PlacementQuestionAnswers.OrderBy(a=>a.OrderNo))
                            }).OrderBy(a => a.OrderNo).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
