using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingExamAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.WritingContext.WritingExamAggregate
{
    public class WritingExamSectionQueryFacade : IWritingExamSectionQueryFacade
    {
        public IEnumerable<WritingExamSectionQueryFacadeDto> GetWritingExamSectionListForGridView(ref DataTableAjaxPostModel filters, Guid id)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.WritingExamSections.Where(a => a.WritingExamId == id && a.IsDeleted == false)
                                select new WritingExamSectionQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    Title = i.Title,
                                    WritingTopic = i.WritingTopic,
                                    TimerMinuties = i.TimerMinuties,
                                    IsActive = i.IsActive,
                                    IsDeleted = i.IsDeleted,
                                    WritingExamId = i.WritingExamId
                                });

                    var Result = data.Where(v =>
                                (titleSerach == null ||
                                (titleSerach != null && (v.Title.Contains(titleSerach.ToString()))
                                                                      ))).AsQueryable();

                    filters.filteredResultsCount = Result.Count();

                    var sort = (filters.order != null ? filters.columns[filters.order[0].column].data : "") + " " + (filters.order != null ? filters.order[0].dir.ToLower() : "");

                    Result = Result.OrderBy(sort).Skip(filters.start).Take(filters.length);

                    var ResultFinal = Result.ToList();
                    return ResultFinal.ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public WritingExamSectionQueryFacadeDto GetWritingExamSectionById(Guid writingExamSectionId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.WritingExamSections.Where(a => a.IsActive == true &&
                            a.IsDeleted == false && a.Id == writingExamSectionId)
                            select new WritingExamSectionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                TimerMinuties = i.TimerMinuties,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                WritingExamId=i.WritingExamId,
                                WritingTopic = i.WritingTopic
                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<WritingExamSectionQueryFacadeDto> GetWritingExamSectionList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.WritingExamSections.Where(a => a.IsActive == true &&
                            a.IsDeleted == false )
                            select new WritingExamSectionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                TimerMinuties = i.TimerMinuties,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                WritingExamId = i.WritingExamId,
                                WritingTopic = i.WritingTopic
                            }).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<WritingExamSectionQueryFacadeDto> GetWritingExamSectionListForUserPanel(Guid writingExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.WritingExamSections.Where(a => a.WritingExamId == writingExamId && a.IsActive == true && a.IsDeleted == false)
                                select new WritingExamSectionQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    Title = i.Title,
                                    WritingTopic = i.WritingTopic,
                                    TimerMinuties = i.TimerMinuties,
                                    IsActive = i.IsActive,
                                    IsDeleted = i.IsDeleted,
                                    WritingExamId = i.WritingExamId
                                });

                    return data.ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<WrtingExamUserAnswersPerSectionQueryFacade> GetWrtingExamUserAnswersPerSectionByExamId(Guid? id, Guid customerId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.WritingExamSections.Where(a => a.IsActive == true && a.IsDeleted == false)
                            join writingExam in context.WritingExams on i.WritingExamId equals writingExam.Id where writingExam.Id == id
                            //let writingExam = (from we in context.WritingExams where i.WritingExamId == we.Id select we).FirstOrDefault(a=>a.IeltsExamId==examId)
                            let userAnswer = (from ua in context.WritingUserAnswers where i.Id == ua.WritingExamSectionId select ua).FirstOrDefault()
                            let user = (from us in context.AspUsers where userAnswer.CustomerId.ToString() == us.Id select us).FirstOrDefault(c=>c.Id==customerId.ToString())


                            select new WrtingExamUserAnswersPerSectionQueryFacade()
                            {
                                IeltsExamId = writingExam.IeltsExamId,
                                WritingExamId = writingExam.Id,
                                WritingExamSectionId = i.Id,
                                WritingTopic = i.WritingTopic,
                                SectionTitle=i.Title,
                                AnswerText = userAnswer.AnswerText,
                                CustomerId = customerId,//Guid.Parse(user.Id),
                                CustomerName=user.UserName

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
