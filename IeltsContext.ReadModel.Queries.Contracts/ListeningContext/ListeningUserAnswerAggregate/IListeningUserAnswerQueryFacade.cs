using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningUserAnswerAggregate.DataContracts;
using Framework.Facade;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningUserAnswerAggregate
{
    public interface IListeningUserAnswerQueryFacade:IQueryFacade
    {
        IEnumerable<ListeningUserAnswerQueryFacadeDto> GetListeningUserAnswerList();
        ListeningUserAnswerQueryFacadeDto GetListeningUserAnswer(Guid listeningUserAnswerId);
        IEnumerable<ListeningUserAnswerQueryFacadeDto> GetListeningExamUserAnswerListByIeltsExamId(ref DataTableAjaxPostModel filters, Guid? listeningExamId, Guid? ieltsExamParticipantsId);
        IEnumerable<ListeningUserAnswerQueryFacadeDto> GetListeningExamUserAnswerListUserPanel(ref DataTableAjaxPostModel filters, Guid listeningExamId, Guid ieltsExamParticipantsId, Guid customerId);
    }
}
