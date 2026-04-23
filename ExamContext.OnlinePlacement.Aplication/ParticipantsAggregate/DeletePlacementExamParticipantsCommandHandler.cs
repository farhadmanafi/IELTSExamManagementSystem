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
    public class DeletePlacementExamParticipantsCommandHandler : ICommandHandler<DeletePlacementExamParticipantsCommand>
    {
        private readonly IPlacementExamParticipantsRepository placementExamParticipantsRepository;
        public DeletePlacementExamParticipantsCommandHandler(IPlacementExamParticipantsRepository placementExamParticipantsRepository)
        {
            this.placementExamParticipantsRepository = placementExamParticipantsRepository;
        }
        public void Execute(DeletePlacementExamParticipantsCommand command)
        {
            var placementExamParticipants = placementExamParticipantsRepository.GetPlacementExamParticipants(command.Id);
            placementExamParticipants.IsDeleted = true;
            placementExamParticipants.IsActive = false;

            placementExamParticipantsRepository.UpdatePlacementExamParticipants(placementExamParticipants);
        }
    }
}
