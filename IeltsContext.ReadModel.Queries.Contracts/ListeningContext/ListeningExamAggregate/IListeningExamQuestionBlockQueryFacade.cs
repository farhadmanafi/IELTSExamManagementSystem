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
    public interface IListeningExamQuestionBlockQueryFacade : IQueryFacade
    {
        IEnumerable<ListeningExamQuestionBlockQueryFacadeDto> GetListeningExamQuestionBlocList();
        IEnumerable<ListeningExamQuestionBlockQueryFacadeDto> GetListeningExamQuestionBlocListByListeningSectionId(Guid listeningExamSectionId);
        ListeningExamQuestionBlockQueryFacadeDto GetListeningExamQuestionBlock(Guid ListeningExamQuestionBlocId);
        IEnumerable<ListeningExamQuestionBlockQueryFacadeDto> GetListeningExamQuestionBlockListForGridView(ref DataTableAjaxPostModel filters, Guid id);
    }
}
