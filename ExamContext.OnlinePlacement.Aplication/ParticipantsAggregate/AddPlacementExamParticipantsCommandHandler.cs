using ExamContext.OnlinePlacement.Aplication.Contracts.ParticipantsAggregate;
using ExamContext.OnlinePlacement.Domain.Contracts.ParticipantsAggregate;
using ExamContext.OnlinePlacement.Domain.ParticipantsAggregate;
using ExamContext.OnlinePlacement.Domain.ParticipantsAggregate.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Aplication.ParticipantsAggregate
{
    public class AddPlacementExamParticipantsCommandHandler : ICommandHandler<AddPlacementExamParticipantsCommand>
    {
        private readonly IPlacementExamParticipantsRepository placementExamParticipantsRepository;
        public AddPlacementExamParticipantsCommandHandler(IPlacementExamParticipantsRepository placementExamParticipantsRepository)
        {
            this.placementExamParticipantsRepository = placementExamParticipantsRepository;
        }
        public void Execute(AddPlacementExamParticipantsCommand command)
        {
            var placementExamParticipantsDto = Mapper.Map<AddPlacementExamParticipantsCommand, PlacementExamParticipantsDto>(command);
            var placementExamParticipants = new PlacementExamParticipants(placementExamParticipantsDto);

            placementExamParticipantsRepository.AddPlacementExamParticipants(placementExamParticipants);
        }
    }
}
