using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementExamAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementExamAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Aplication.PlacementExamAggregate
{
    public class DeletePlacementExamCommandHandler : ICommandHandler<DeletePlacementExamCommand>
    {
        private readonly IPlacementExamRepository _iPlacementExamRepository;
        public DeletePlacementExamCommandHandler(IPlacementExamRepository iPlacementExamRepository)
        {
            _iPlacementExamRepository = iPlacementExamRepository;
        }
        public void Execute(DeletePlacementExamCommand command)
        {
            var placementExam = _iPlacementExamRepository.GetPlacementExam(command.Id);
            placementExam.IsDeleted = true;
            placementExam.IsActive = false;

            _iPlacementExamRepository.UpdatePlacementExam(placementExam);
        }
    }
}
