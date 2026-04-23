using ExamContext.OnlinePlacement.Domain.PlacementUserScoreAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementUserScoreAggregate.Services;
using ExamContext.OnlinePlacement.Domain.Contracts.PlacementUserScoreAggregate;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementUserScoreAggregate;

namespace ExamContext.OnlinePlacement.Aplication.PlacementUserScoreAggregate
{
    public class AddPlacementUserScoreCommandHandler : ICommandHandler<AddPlacementUserScoreCommand>
    {
        private readonly IPlacementUserScoreRepository _iPlacementUserScoreRepository;
        public AddPlacementUserScoreCommandHandler(IPlacementUserScoreRepository iPlacementUserScoreRepository)
        {
            _iPlacementUserScoreRepository = iPlacementUserScoreRepository;
        }
        public void Execute(AddPlacementUserScoreCommand command)
        {
            var placementUserScoreDto = Mapper.Map<AddPlacementUserScoreCommand, PlacementUserScoreDto>(command);
            var placementUserScore = new PlacementUserScore(placementUserScoreDto);

            _iPlacementUserScoreRepository.AddPlacementUserScore(placementUserScore);
        }
    }
}
