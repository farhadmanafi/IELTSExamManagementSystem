using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementUserScoreAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementUserScoreAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Aplication.PlacementUserScoreAggregate
{
    public class UpdatePlacementUserScoreLevelCommandHandler : ICommandHandler<UpdatePlacementUserScoreLevelCommand>
    {
        private readonly IPlacementUserScoreRepository _iPlacementUserScoreRepository;
        public UpdatePlacementUserScoreLevelCommandHandler(IPlacementUserScoreRepository iPlacementUserScoreRepository)
        {
            _iPlacementUserScoreRepository = iPlacementUserScoreRepository;
        }
        public void Execute(UpdatePlacementUserScoreLevelCommand command)
        {
            var PlacementUserScore = _iPlacementUserScoreRepository.GetPlacementUserScore(command.Id);
            PlacementUserScore.LevelScoreId = command.LevelScoreId;

            _iPlacementUserScoreRepository.UpdatePlacementUserScore(PlacementUserScore);
        }
    }
}
