using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamMeetingAggregate;
using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamMeetingAggregate.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Facade.SpeakingContext.SpeakingExamMeetingAggregate
{
    public class SpeakingExamMeetingReserveQueryFacade : ISpeakingExamMeetingReserveQueryFacade
    {
        public SpeakingExamMeetingReserveQueryFacadeDto GetSpeakingExamMeetingReserve(Guid speakingExamMeetingReserveId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.SpeakingExamMeetingReserves.Where(a => a.IsActive == true && a.IsDeleted == false && a.Id == speakingExamMeetingReserveId)
                            select new SpeakingExamMeetingReserveQueryFacadeDto()
                            {
                                Id = i.Id,
                                SpeakingExamMeetingId = i.SpeakingExamMeetingId,
                                CustomerId = i.CustomerId,
                                IeltsExamParticipantId = i.IeltsExamParticipantId,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted
                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public SpeakingExamMeetingReserveQueryFacadeDto GetSpeakingExamMeetingReserveByIeltsExamParticipantId(Guid ieltsExamParticipantId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.SpeakingExamMeetingReserves.Where(a => a.IeltsExamParticipantId == ieltsExamParticipantId)
                            let speakingExamMeeting = (from le in context.SpeakingExamMeetings where i.SpeakingExamMeetingId == le.Id select le).FirstOrDefault()
                            select new SpeakingExamMeetingReserveQueryFacadeDto()
                            {
                                Id = i.Id,
                                SpeakingExamMeetingId = i.SpeakingExamMeetingId,
                                CustomerId = i.CustomerId,
                                IeltsExamParticipantId = i.IeltsExamParticipantId,
                                SpeakingExamMeetingTitle = speakingExamMeeting.Title + " _ " + speakingExamMeeting.MeetingStartTime + " - " + speakingExamMeeting.MeetingEndTime,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted
                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<SpeakingExamMeetingReserveQueryFacadeDto> GetSpeakingExamMeetingReserveList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.SpeakingExamMeetingReserves.Where(a => a.IsActive == true && a.IsDeleted == false)
                            select new SpeakingExamMeetingReserveQueryFacadeDto()
                            {
                                Id = i.Id,
                                SpeakingExamMeetingId = i.SpeakingExamMeetingId,
                                CustomerId = i.CustomerId,
                                IeltsExamParticipantId = i.IeltsExamParticipantId,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted
                            }).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
