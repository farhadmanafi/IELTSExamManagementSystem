using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningExamAggregate.DataContracts;
using Framework.Facade;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningExamAggregate
{
    public interface IListeningExamQueryFacade:IQueryFacade
    {
        IEnumerable<ListeningExamQueryFacadeDto> GetListeningExamList();
        IEnumerable<ListeningExamQueryFacadeDto> GetListeningExamByFilteringList(ref DataTableAjaxPostModel filters, Guid examId);
        ListeningExamQueryFacadeDto GetListeningExamById(Guid listeningExamId);
        Guid GetIeltsExamByListeningExamId(Guid listeningExamId);
        int GetListeningExamCount(Guid id);
        ListeningExamQueryFacadeDto GetListeningExamForUserPanel(Guid id);
    }
}
