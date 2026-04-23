using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementUserAnswerAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementUserAnswerAggregate.Services;
using ExamContext.OnlinePlacement.Domain.PlacementUserAnswerAggregate;
using ExamContext.OnlinePlacement.Domain.Contracts.PlacementUserAnswerAggregate;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamContext.OnlinePlacement.Domain.PlacementUserScoreAggregate.Services;
using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementUserScoreAggregate;
using ExamContext.OnlinePlacement.Domain.Contracts.PlacementUserScoreAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementUserScoreAggregate;

namespace ExamContext.OnlinePlacement.Aplication.PlacementUserAnswerAggregate
{
    public class PlacementUserAnswerCommandHandler : ICommandHandler<PlacementUserAnswerCommand>
    {
        private readonly IPlacementUserAnswerRepository iPlacementUserAnswerRepository;
        private readonly IPlacementUserScoreRepository iPlacementUserScoreRepository;
        public PlacementUserAnswerCommandHandler(IPlacementUserAnswerRepository iPlacementUserAnswerRepository,
            IPlacementUserScoreRepository iPlacementUserScoreRepository)
        {
            this.iPlacementUserAnswerRepository = iPlacementUserAnswerRepository;
            this.iPlacementUserScoreRepository = iPlacementUserScoreRepository;
        }
        public void Execute(PlacementUserAnswerCommand command)
        {
            var placementUserScoreDto = Mapper.Map<AddPlacementUserScoreCommand, PlacementUserScoreDto>(command.addPlacementUserScoreCommand);
            var placementUserScore = new PlacementUserScore(placementUserScoreDto);

            iPlacementUserScoreRepository.AddPlacementUserScore(placementUserScore);

            foreach (var item in command.addPlacementUserAnswerList)
            {
                var placementUserAnswerDto = Mapper.Map<AddPlacementUserAnswerCommand, PlacementUserAnswerDto>(item);
                placementUserAnswerDto.PlacementUserScoreId = placementUserScore.Id;
                var placementUserAnswer = new PlacementUserAnswer(placementUserAnswerDto);

                iPlacementUserAnswerRepository.AddPlacementUserAnswer(placementUserAnswer);
            }
        }
    }
}
