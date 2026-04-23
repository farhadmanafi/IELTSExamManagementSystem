using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementExamAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementExamAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementExamAggregate.Services;
using ExamContext.OnlinePlacement.Domain.Contracts.PlacementExamAggregate;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Aplication.PlacementExamAggregate
{
    public class AddPlacementExamCommandHandler : ICommandHandler<AddPlacementExamCommand>
    {
        private readonly IPlacementExamRepository _iPlacementExamRepository;
        public AddPlacementExamCommandHandler(IPlacementExamRepository iPlacementExamRepository)
        {
            _iPlacementExamRepository = iPlacementExamRepository;
        }
        public void Execute(AddPlacementExamCommand command)
        {
            var placementExamDto = Mapper.Map<AddPlacementExamCommand, PlacementExamDto>(command);
            var placementExam = new PlacementExam(placementExamDto);

            _iPlacementExamRepository.AddPlacementExam(placementExam);
        }
    }
}
