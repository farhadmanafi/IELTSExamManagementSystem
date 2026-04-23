using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingUserAnswerAggregate;
using ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingUserAnswerAggregate.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Facade.WritingContext.WritingUserAnswerAggregate
{
    public class WritingUserAnswerQueryFacade : IWritingUserAnswerQueryFacade
    {
        public WritingUserAnswerQueryFacadeDto GetWritingUserAnswer(Guid writingUserAnswerId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.WritingUserAnswers.Where(a => a.IsActive == true && a.IsDeleted == false && a.Id == writingUserAnswerId)
                            select new WritingUserAnswerQueryFacadeDto()
                            {
                                Id = i.Id,
                                WritingExamSectionId = i.WritingExamSectionId,
                                IeltsExamParticipantId = i.IeltsExamParticipantId,
                                AnswerText = i.AnswerText,
                                CustomerId = i.CustomerId,
                                RegisterDateTime = i.RegisterDateTime,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<WritingUserAnswerQueryFacadeDto> GetWritingUserAnswerList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.WritingUserAnswers.Where(a => a.IsActive == true && a.IsDeleted == false )
                            select new WritingUserAnswerQueryFacadeDto()
                            {
                                Id = i.Id,
                                WritingExamSectionId = i.WritingExamSectionId,
                                IeltsExamParticipantId = i.IeltsExamParticipantId,
                                AnswerText = i.AnswerText,
                                CustomerId = i.CustomerId,
                                RegisterDateTime = i.RegisterDateTime,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
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
