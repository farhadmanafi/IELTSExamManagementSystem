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
    public interface IListeningQuestionAnswersQueryFacade : IQueryFacade
    {
        IEnumerable<ListeningQuestionAnswersQueryFacadeDto> GetListeningQuestionAnswersList();
        ListeningQuestionAnswersQueryFacadeDto GetListeningQuestionAnswers(Guid listeningQuestionAnswersId);
        IEnumerable<ListeningQuestionAnswersQueryFacadeDto> GetListeningQuestionAnswerListForGridView(ref DataTableAjaxPostModel filters, Guid id);
    }
}
