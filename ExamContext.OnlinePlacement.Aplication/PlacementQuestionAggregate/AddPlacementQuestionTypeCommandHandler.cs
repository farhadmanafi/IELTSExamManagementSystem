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
    public class AddPlacementQuestionTypeCommandHandler : ICommandHandler<AddPlacementQuestionTypeCommand>
    {
        private readonly IPlacementQuestionTypeRepository _iPlacementQuestionTypeRepository;
        public AddPlacementQuestionTypeCommandHandler(IPlacementQuestionTypeRepository iPlacementQuestionTypeRepository)
        {
            _iPlacementQuestionTypeRepository = iPlacementQuestionTypeRepository;
        }
        public void Execute(AddPlacementQuestionTypeCommand command)
        {
            var PlacementQuestionTypeDto = Mapper.Map<AddPlacementQuestionTypeCommand, PlacementQuestionTypeDto>(command);
            var placementQuestionType = new PlacementQuestionType(PlacementQuestionTypeDto);

            _iPlacementQuestionTypeRepository.AddPlacementQuestionType(placementQuestionType);
        }
    }
}
