using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementUserAnswerAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementExamAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Aplication.PlacementUserAnswerAggregate
{
    public class UpdatePlacementUserAnswerCommandHandler : ICommandHandler<UpdatePlacementUserAnswerCommand>
    {
        private readonly IPlacementExamRepository _iPlacementExamRepository;
        public UpdatePlacementUserAnswerCommandHandler(IPlacementExamRepository iPlacementExamRepository)
        {
            _iPlacementExamRepository = iPlacementExamRepository;
        }
        public void Execute(UpdatePlacementUserAnswerCommand command)
        {
            var placementExam = _iPlacementExamRepository.GetPlacementExam(command.Id);
            //Changest

            _iPlacementExamRepository.UpdatePlacementExam(placementExam);
        }
    }
}
