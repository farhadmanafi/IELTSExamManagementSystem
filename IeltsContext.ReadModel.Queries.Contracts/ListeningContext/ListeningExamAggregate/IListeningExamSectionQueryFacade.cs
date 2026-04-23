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
    public interface IListeningExamSectionQueryFacade:IQueryFacade
    {
        IEnumerable<ListeningExamSectionQueryFacadeDto> GetListeningExamSectionList();
        IEnumerable<ListeningExamSectionQueryFacadeDto> GetListeningExamSectionListByListeningExamId(Guid listeningExamId);
        ListeningExamSectionQueryFacadeDto GetListeningExamSection(Guid ListeningExamSectionId);
        IEnumerable<ListeningExamSectionQueryFacadeDto> GetListeningExamSectionListForGridView(ref DataTableAjaxPostModel filters, Guid id);
    }
}
