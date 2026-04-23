using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamAggregate.DataContracts;
using Framework.Facade;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamAggregate
{
    public interface ISpeakingExamQueryFacade:IQueryFacade
    {
        IEnumerable<SpeakingExamQueryFacadeDto> GetSpeakingExamList();
        IEnumerable<SpeakingExamQueryFacadeDto> GetSpeakingExamByFilteringList(ref DataTableAjaxPostModel filters, Guid ieltsExamId);
        SpeakingExamQueryFacadeDto GetSpeakingExamById(Guid speakingExamId);
        int GetSpeakingExamCount(Guid id);
        SpeakingExamQueryFacadeDto GetSpeakingExamForUserPanel(Guid id);
        Guid GetIeltsExamBySpeakingExamId(Guid speakingExamId);
    }
}
