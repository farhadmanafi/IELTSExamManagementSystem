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
    public class AddPlacementQuestionCommandHandler : ICommandHandler<AddPlacementQuestionCommand>
    {
        private readonly IPlacementQuestionRepository _iPlacementQuestionRepository;
        public AddPlacementQuestionCommandHandler(IPlacementQuestionRepository iPlacementQuestionRepository)
        {
            _iPlacementQuestionRepository = iPlacementQuestionRepository;
        }
        public void Execute(AddPlacementQuestionCommand command)
        {
            var PlacementQuestionDto = Mapper.Map<AddPlacementQuestionCommand, PlacementQuestionDto>(command);
            var placementQuestion = new PlacementQuestion(PlacementQuestionDto);

            _iPlacementQuestionRepository.AddPlacementQuestion(placementQuestion);
        }
    }
}
