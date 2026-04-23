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
    public class DeletePlacementQuestionTypeCommandHandler : ICommandHandler<DeletePlacementQuestionTypeCommand>
    {
        private readonly IPlacementQuestionTypeRepository _iPlacementQuestionTypeRepository;
        public DeletePlacementQuestionTypeCommandHandler(IPlacementQuestionTypeRepository iPlacementQuestionTypeRepository)
        {
            _iPlacementQuestionTypeRepository = iPlacementQuestionTypeRepository;
        }
        public void Execute(DeletePlacementQuestionTypeCommand command)
        {
            var PlacementQuestionType = _iPlacementQuestionTypeRepository.GetPlacementQuestionType(command.Id);
            PlacementQuestionType.IsDeleted = true;
            PlacementQuestionType.IsActive = false;

            _iPlacementQuestionTypeRepository.UpdatePlacementQuestionType(PlacementQuestionType);
        }
    }
}
