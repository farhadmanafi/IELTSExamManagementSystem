using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningQuestionAggregate.DataContracts;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningQuestionAggregate
{
    public interface IListeningQuestionTypeQueryFacade:IQueryFacade
    {
        IEnumerable<ListeningQuestionTypeQueryFacadeDto> GetListeningQuestionTypeListQueryFacade();
        ListeningQuestionTypeQueryFacadeDto GetListeningQuestionTypeQueryFacade(Guid listeningQuestionTypeId);
    }
}
