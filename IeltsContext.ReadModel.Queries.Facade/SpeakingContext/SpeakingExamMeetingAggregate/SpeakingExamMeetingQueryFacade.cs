using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamMeetingAggregate;
using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamMeetingAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.SpeakingContext.SpeakingExamMeetingAggregate
{
    public class SpeakingExamMeetingQueryFacade : ISpeakingExamMeetingQueryFacade
    {
        public SpeakingExamMeetingQueryFacadeDto GetSpeakingExamMeeting(Guid speakingExamMeetingId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.SpeakingExamMeetings.Where(a => a.IsActive == true && a.IsDeleted == false && a.Id == speakingExamMeetingId)
                            select new SpeakingExamMeetingQueryFacadeDto()
                            {
                                Id = i.Id,
                                SpeakingExamId = i.SpeakingExamId,
                                Title = i.Title,
                                MeetingDate = i.MeetingDate,
                                MeetingStartTime = i.MeetingStartTime,
                                MeetingEndTime = i.MeetingEndTime,
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

        public IEnumerable<SpeakingExamMeetingQueryFacadeDto> GetSpeakingExamMeetingList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.SpeakingExamMeetings.Where(a => a.IsDeleted == false)
                            select new SpeakingExamMeetingQueryFacadeDto()
                            {
                                Id = i.Id,
                                SpeakingExamId = i.SpeakingExamId,
                                Title = i.Title,
                                MeetingDate = i.MeetingDate,
                                MeetingStartTime = i.MeetingStartTime,
                                MeetingEndTime = i.MeetingEndTime,
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

        public IEnumerable<SpeakingExamMeetingQueryFacadeDto> GetSpeakingExamMeetingListForGridView(ref DataTableAjaxPostModel filters, Guid speakingExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                    var data = (from i in context.SpeakingExamMeetings.Where(a => a.SpeakingExamId == speakingExamId && a.IsDeleted == false)
                                select new SpeakingExamMeetingQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    SpeakingExamId = i.SpeakingExamId,
                                    Title = i.Title,
                                    MeetingDate = i.MeetingDate,
                                    MeetingStartTime = i.MeetingStartTime,
                                    MeetingEndTime = i.MeetingEndTime,
                                    IsActive = i.IsActive,
                                    IsDeleted = i.IsDeleted
                                });

                    var Result = data.Where(v =>
                                (titleSerach == null ||
                                (titleSerach != null && (v.Title.Contains(titleSerach.ToString()))
                                                                      ))).AsQueryable();

                    filters.filteredResultsCount = Result.Count();

                    var sort = (filters.order != null ? filters.columns[filters.order[0].column].data : "") + " " + (filters.order != null ? filters.order[0].dir.ToLower() : "");

                    sort = sort == "meetingDate_Persian desc" ? "meetingDate desc" : sort;
                    sort = sort == "meetingDate_Persian asc" ? "meetingDate asc" : sort;

                    Result = Result.OrderBy(sort).Skip(filters.start).Take(filters.length);

                    var ResultFinal = Result.ToList();
                    ResultFinal.ForEach(a => a.MeetingDate_Persian = DateConverter.MiladiToShamsiConvert(a.MeetingDate, true));
                    return ResultFinal.ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<SpeakingExamMeetingQueryFacadeDto> GetSpeakingExamMeetingListForUserPanel(Guid speakingExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.SpeakingExamMeetings.Where(a => a.SpeakingExamId == speakingExamId && a.IsActive == true && a.IsDeleted == false)
                            select new SpeakingExamMeetingQueryFacadeDto()
                            {
                                Id = i.Id,
                                SpeakingExamId = i.SpeakingExamId,
                                Title = i.Title + " ("+ DateConverter.MiladiToShamsiConvert(i.MeetingDate, false) + " " + i.MeetingStartTime + "-" + i.MeetingEndTime + ")",
                                MeetingDate = i.MeetingDate,
                                MeetingStartTime = i.MeetingStartTime,
                                MeetingEndTime = i.MeetingEndTime,
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
