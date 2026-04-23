using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementQuestionAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementQuestionAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Aplication.PlacementQuestionAggregate
{
    public class UpdatePlacementQuestionTypeCommandHandler : ICommandHandler<UpdatePlacementQuestionTypeCommand>
    {
        private readonly IPlacementQuestionTypeRepository _iPlacementQuestionTypeRepository;
        public UpdatePlacementQuestionTypeCommandHandler(IPlacementQuestionTypeRepository iPlacementQuestionTypeRepository)
        {
            _iPlacementQuestionTypeRepository = iPlacementQuestionTypeRepository;
        }
        public void Execute(UpdatePlacementQuestionTypeCommand command)
        {
            var PlacementQuestionType = _iPlacementQuestionTypeRepository.GetPlacementQuestionType(command.Id);
            //Changest

            _iPlacementQuestionTypeRepository.UpdatePlacementQuestionType(PlacementQuestionType);
        }
    }
}
