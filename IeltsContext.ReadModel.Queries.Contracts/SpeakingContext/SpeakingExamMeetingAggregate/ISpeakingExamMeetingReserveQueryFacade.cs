using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamMeetingAggregate.DataContracts;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamMeetingAggregate
{
    public interface ISpeakingExamMeetingReserveQueryFacade:IQueryFacade
    {
        IEnumerable<SpeakingExamMeetingReserveQueryFacadeDto> GetSpeakingExamMeetingReserveList();
        SpeakingExamMeetingReserveQueryFacadeDto GetSpeakingExamMeetingReserve(Guid speakingExamMeetingReserveId);
        SpeakingExamMeetingReserveQueryFacadeDto GetSpeakingExamMeetingReserveByIeltsExamParticipantId(Guid ieltsExamParticipantId);

    }
}
