using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.ParticipantsAggregate.DataContracts;
using Framework.Facade;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.ParticipantsAggregate
{
    public interface IOnlinePlacementParticipantsQueryFacade : IQueryFacade
    {
        IEnumerable<OnlinePlacementParticipantsQueryFacadeDto> GetOnlinePlacementFilteringList(ref DataTableAjaxPostModel filters, Guid OnlinePlacementId);
        IEnumerable<OnlinePlacementParticipantsQueryFacadeDto> GetOnlinePlacementFilteringListByCustomerId(ref DataTableAjaxPostModel filters, Guid customerId);
        Guid GetCustomerIdFromParticipantId(Guid participantId);
    }
}
