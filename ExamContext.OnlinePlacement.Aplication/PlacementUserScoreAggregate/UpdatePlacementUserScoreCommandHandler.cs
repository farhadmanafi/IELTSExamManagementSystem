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
    public class UpdatePlacementUserScoreCommandHandler : ICommandHandler<UpdatePlacementUserScoreCommand>
    {
        private readonly IPlacementUserScoreRepository _iPlacementUserScoreRepository;
        public UpdatePlacementUserScoreCommandHandler(IPlacementUserScoreRepository iPlacementUserScoreRepository)
        {
            _iPlacementUserScoreRepository = iPlacementUserScoreRepository;
        }
        public void Execute(UpdatePlacementUserScoreCommand command)
        {
            var PlacementUserScore = _iPlacementUserScoreRepository.GetPlacementUserScore(command.Id);
            //Changest

            _iPlacementUserScoreRepository.UpdatePlacementUserScore(PlacementUserScore);
        }
    }
}
