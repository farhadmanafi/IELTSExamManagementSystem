using ExamContext.OnlinePlacement.Domain.ParticipantsAggregate;
using ExamContext.OnlinePlacement.Domain.ParticipantsAggregate.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Persistence.ParticipantsAggregate
{
    public class PlacementExamParticipantsRepository : RepositoryBase<PlacementExamParticipants>, IPlacementExamParticipantsRepository
    {
        public PlacementExamParticipantsRepository(IDbContext context) : base(context)
        {

        }

        public void AddPlacementExamParticipants(PlacementExamParticipants placementExamParticipants)
        {
            Set.Add(placementExamParticipants);
        }

        public PlacementExamParticipants GetPlacementExamParticipants(Guid id)
        {
            return Set.SingleOrDefault(a => a.Id == id);
        }

        public void UpdatePlacementExamParticipants(PlacementExamParticipants placementExamParticipants)
        {
            Set.Update(placementExamParticipants);
        }
    }
}
