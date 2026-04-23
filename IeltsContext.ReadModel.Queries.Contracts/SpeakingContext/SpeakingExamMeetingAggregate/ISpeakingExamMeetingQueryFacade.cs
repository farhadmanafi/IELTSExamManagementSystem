using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamMeetingAggregate.DataContracts;
using Framework.Facade;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamMeetingAggregate
{
    public interface ISpeakingExamMeetingQueryFacade : IQueryFacade
    {
        IEnumerable<SpeakingExamMeetingQueryFacadeDto> GetSpeakingExamMeetingList();
        IEnumerable<SpeakingExamMeetingQueryFacadeDto> GetSpeakingExamMeetingListForGridView(ref DataTableAjaxPostModel filters, Guid speakingExamId);
        SpeakingExamMeetingQueryFacadeDto GetSpeakingExamMeeting(Guid speakingExamMeetingId);
        IEnumerable<SpeakingExamMeetingQueryFacadeDto> GetSpeakingExamMeetingListForUserPanel(Guid speakingExamId);
    }
}
