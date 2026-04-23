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
    public class DeletePlacementUserScoreCommandHandler : ICommandHandler<DeletePlacementUserScoreCommand>
    {
        private readonly IPlacementUserScoreRepository _iPlacementUserScoreRepository;
        public DeletePlacementUserScoreCommandHandler(IPlacementUserScoreRepository iPlacementUserScoreRepository)
        {
            _iPlacementUserScoreRepository = iPlacementUserScoreRepository;
        }
        public void Execute(DeletePlacementUserScoreCommand command)
        {
            var placementUserScore = _iPlacementUserScoreRepository.GetPlacementUserScore(command.Id);
            placementUserScore.IsDeleted = true;
            placementUserScore.IsActive = false;

            _iPlacementUserScoreRepository.UpdatePlacementUserScore(placementUserScore);
        }
    }
}
