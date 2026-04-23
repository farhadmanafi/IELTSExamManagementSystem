using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate.DataContracts;
using Framework.Facade;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate
{
    public interface IIeltsExamParticipantsQueryFacade : IQueryFacade
    {
        IEnumerable<IeltsExamParticipantsQueryFacadeDto> GetIeltsExamFilteringList(ref DataTableAjaxPostModel filters, Guid ieltsExamId);
        IEnumerable<IeltsExamParticipantsQueryFacadeDto> GetIeltsExamFilteringListByCustomerId(ref DataTableAjaxPostModel filters, Guid customerId);
        Guid GetCustomerIdFromParticipantId(Guid participantId);
    }
}
