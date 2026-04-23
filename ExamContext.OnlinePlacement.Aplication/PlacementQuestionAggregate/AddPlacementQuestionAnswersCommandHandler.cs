using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementQuestionAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementQuestionAggregate.Services;
using ExamContext.OnlinePlacement.Domain.PlacementQuestionAggregate;
using ExamContext.OnlinePlacement.Domain.Contracts.PlacementQuestionAggregate;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Aplication.PlacementQuestionAggregate
{
    public class AddPlacementQuestionAnswersCommandHandler : ICommandHandler<AddPlacementQuestionAnswersCommand>
    {
        private readonly IPlacementQuestionAnswersRepository _iPlacementQuestionAnswersRepository;
        public AddPlacementQuestionAnswersCommandHandler(IPlacementQuestionAnswersRepository iPlacementQuestionAnswersRepository)
        {
            _iPlacementQuestionAnswersRepository = iPlacementQuestionAnswersRepository;
        }
        public void Execute(AddPlacementQuestionAnswersCommand command)
        {
            var PlacementQuestionAnswersDto = Mapper.Map<AddPlacementQuestionAnswersCommand, PlacementQuestionAnswersDto>(command);
            var placementQuestionAnswers = new PlacementQuestionAnswers(PlacementQuestionAnswersDto);

            _iPlacementQuestionAnswersRepository.AddPlacementQuestionAnswers(placementQuestionAnswers);
        }
    }
}
