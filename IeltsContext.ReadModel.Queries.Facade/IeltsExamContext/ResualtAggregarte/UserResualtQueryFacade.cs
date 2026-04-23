using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ResualtAggregarte.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.IeltsExamContext.ResualtAggregarte
{
    public class UserResualtQueryFacade : IUserResualtQueryFacade
    {
        public IeltsExamUserResultQueryFacadeDto GetUserExamResult(Guid participantsId, Guid customerId)
        {
            using (var context = new ExamContextReadModelDBContext())
            {
                var data = (from c in context.UserResualts.Where(a => a.ParticipantsId == participantsId && a.CustomerId == customerId)
                        let user = (from us in context.AspUsers where c.CustomerId.ToString() == us.Id select us).FirstOrDefault()
                        select new IeltsExamUserResultQueryFacadeDto()
                        {
                            UserId  = c.UserId,
                            CustomerId = c.CustomerId,
                            IeltsExamParticipantsId = c.ParticipantsId,
                            FinalScore = c.FinalScore,
                            ListeningScore = c.ListeningScore,
                            ReadingScore = c.ReadingScore,
                            SpeakingScore = c.SpeakingScore,
                            WritingScore = c.WritingScore,
                            IsActive = c.IsActive,
                            IsDeleted = c.IsDeleted,
                            CustomerName = user.UserName
                        });

                return data?.FirstOrDefault();
            }
        }

        public IEnumerable<UserExamResultListQueryFacade> GetUserExamResultFilteringList(ref DataTableAjaxPostModel filters, Guid customerId, Guid ieltsExamParticipantsId)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                var userExamResult = GetUserExamResult(ieltsExamParticipantsId, customerId);

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.IeltsExamParticipants.Where(a => a.Id == ieltsExamParticipantsId)
                                select new UserExamResultListQueryFacade()
                                {
                                    Id = i.Id,
                                    CustomerId = i.CustomerId,
                                    Title = "آزمون آیلتس",
                                    ListeningScore= userExamResult.ListeningScore,
                                    ReadingScore= userExamResult.ReadingScore,
                                    SpeakingScore= userExamResult.SpeakingScore,
                                    WritingScore= userExamResult.WritingScore
                                });

                    var Result = data;

                    filters.filteredResultsCount = Result.Count();

                    var sort = (filters.order != null ? filters.columns[filters.order[0].column].data : "") + " " + (filters.order != null ? filters.order[0].dir.ToLower() : "");

                    Result = Result.OrderBy(sort).Skip(filters.start).Take(filters.length);

                    return Result.ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
