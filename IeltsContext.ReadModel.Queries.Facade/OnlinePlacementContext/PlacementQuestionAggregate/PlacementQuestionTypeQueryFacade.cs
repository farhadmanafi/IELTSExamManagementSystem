using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementQuestionAggregate.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Facade.OnlinePlacementContext.PlacementQuestionAggregate
{
    public class PlacementQuestionTypeQueryFacade : IPlacementQuestionTypeQueryFacade
    {
        public PlacementQuestionTypeQueryFacadeDto GetPlacementQuestionType(Guid placementQuestionTypeId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.PlacementQuestionTypes.Where(a => a.IsDeleted == false && a.Id == placementQuestionTypeId)
                            select new PlacementQuestionTypeQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                CodeName = i.CodeName,
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

        public IEnumerable<PlacementQuestionTypeQueryFacadeDto> GetPlacementQuestionTypeList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.PlacementQuestionTypes.Where(a => a.IsDeleted == false )
                            select new PlacementQuestionTypeQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                CodeName = i.CodeName,
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
    }
}
