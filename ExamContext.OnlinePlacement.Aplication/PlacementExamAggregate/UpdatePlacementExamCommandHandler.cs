using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementExamAggregate;
using ExamContext.OnlinePlacement.Domain.Contracts.PlacementExamAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementExamAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementExamAggregate.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Aplication.PlacementExamAggregate
{
    public class UpdatePlacementExamCommandHandler : ICommandHandler<UpdatePlacementExamCommand>
    {
        private readonly IPlacementExamRepository _iPlacementExamRepository;
        public UpdatePlacementExamCommandHandler(IPlacementExamRepository iPlacementExamRepository)
        {
            _iPlacementExamRepository = iPlacementExamRepository;
        }
        public void Execute(UpdatePlacementExamCommand command)
        {
            var placementExam = _iPlacementExamRepository.GetPlacementExam(command.Id);
            
            //Changest
            placementExam.TitleSetter(command.Title);
            placementExam.DescriptionSetter(command.Description);
            placementExam.ActivedDate = command.ActivedDate;
            placementExam.DeActivedDate = command.DeActivedDate;
            placementExam.IsActive = command.IsActive;

            //var data = Mapper.Map<PlacementExam, PlacementExamDto>(placementExam);
            //var dataUpdate = new PlacementExam(data);

            //dataUpdate.Id = placementExam.Id;

            _iPlacementExamRepository.UpdatePlacementExam(placementExam);
        }
    }
}
