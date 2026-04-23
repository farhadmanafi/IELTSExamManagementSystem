using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementUserAnswerAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementUserAnswerAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Aplication.PlacementUserAnswerAggregate
{
    public class DeletePlacementUserAnswerCommandHandler : ICommandHandler<DeletePlacementUserAnswerCommand>
    {
        private readonly IPlacementUserAnswerRepository _iPlacementUserAnswerRepository;
        public DeletePlacementUserAnswerCommandHandler(IPlacementUserAnswerRepository iPlacementUserAnswerRepository)
        {
            _iPlacementUserAnswerRepository = iPlacementUserAnswerRepository;
        }
        public void Execute(DeletePlacementUserAnswerCommand command)
        {
            var placementUserAnswer = _iPlacementUserAnswerRepository.GetPlacementUserAnswer(command.Id);
            placementUserAnswer.IsDeleted = true;
            placementUserAnswer.IsActive = false;

            _iPlacementUserAnswerRepository.UpdatePlacementUserAnswer(placementUserAnswer);
        }
    }
}
