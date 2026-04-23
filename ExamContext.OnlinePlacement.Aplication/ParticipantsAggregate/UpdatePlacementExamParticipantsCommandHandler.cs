using ExamContext.OnlinePlacement.Aplication.Contracts.ParticipantsAggregate;
using ExamContext.OnlinePlacement.Domain.ParticipantsAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Aplication.ParticipantsAggregate
{
    public class UpdatePlacementExamParticipantsCommandHandler : ICommandHandler<UpdatePlacementExamParticipantsCommand>
    {
        private readonly IPlacementExamParticipantsRepository placementExamParticipantsRepository;
        public UpdatePlacementExamParticipantsCommandHandler(IPlacementExamParticipantsRepository placementExamParticipantsRepository)
        {
            this.placementExamParticipantsRepository = placementExamParticipantsRepository;
        }
        public void Execute(UpdatePlacementExamParticipantsCommand command)
        {
            var placementExamParticipants = placementExamParticipantsRepository.GetPlacementExamParticipants(command.Id);
            placementExamParticipants.PlacementExamParticipantsStatusId = command.PlacementExamParticipantsStatusId;

            placementExamParticipantsRepository.UpdatePlacementExamParticipants(placementExamParticipants);
        }
    }
}
