using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserScoreAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserScoreAggregate.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Facade.OnlinePlacementContext.PlacementUserScoreAggregate
{
    public class LevelScoreQueryFacade : ILevelScoreQueryFacade
    {
        public LevelScoreQueryFacadeDto GetLevelScore(Guid levelScoreId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.LevelScores.Where(a => a.IsDeleted == false && a.Id == levelScoreId)
                            select new LevelScoreQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                LevelName = i.LevelName,
                                OrderNo = i.OrderNo,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                MinScore = i.MinScore,
                                MaxScore = i.MaxScore
                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<LevelScoreQueryFacadeDto> GetLevelScoreList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.LevelScores.Where(a => a.IsDeleted == false)
                            select new LevelScoreQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                LevelName = i.LevelName,
                                OrderNo = i.OrderNo,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                MinScore = i.MinScore,
                                MaxScore = i.MaxScore
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
