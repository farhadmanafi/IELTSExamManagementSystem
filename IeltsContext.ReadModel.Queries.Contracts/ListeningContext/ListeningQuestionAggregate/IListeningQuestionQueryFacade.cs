using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningQuestionAggregate.DataContracts;
using Framework.Facade;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningQuestionAggregate
{
    public interface IListeningQuestionQueryFacade:IQueryFacade
    {
        IEnumerable<ListeningQuestionQueryFacadeDto> GetListeningQuestionList();
        ListeningQuestionQueryFacadeDto GetListeningQuestion(Guid listeningQuestionId);
        IEnumerable<ListeningQuestionQueryFacadeDto> GetListeningQuestionListForGridView(ref DataTableAjaxPostModel filters, Guid id);
        IEnumerable<ListeningQuestionQueryFacadeDto> GetListeningQuestionUserPanelList(Guid listeningExamId);
    }
}
