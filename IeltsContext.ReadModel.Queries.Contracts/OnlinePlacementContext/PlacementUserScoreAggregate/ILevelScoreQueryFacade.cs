using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserScoreAggregate.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserScoreAggregate
{
    public interface ILevelScoreQueryFacade
    {
        IEnumerable<LevelScoreQueryFacadeDto> GetLevelScoreList();
        LevelScoreQueryFacadeDto GetLevelScore(Guid levelScoreId);
    }
}
