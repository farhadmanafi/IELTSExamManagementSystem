using ExamContext.Reading.Domain.Contracts.ReadingUserAnswerAggregate;
using ExamContext.Reading.Domain.ReadingExamAggregate.Exceptions;
using Framework.Core.Domain;
using Framework.Domain;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Domain.ReadingUserAnswerAggregate
{
    public class ReadingUserAnswer : EntityBase, IAggregateRoot<ReadingUserAnswer>
    {
        public ReadingUserAnswer()
        {

        }
        public ReadingUserAnswer(ReadingUserAnswerDto dto)
        {
            ReadingExamId = dto.ReadingExamId;
            IeltsExamParticipantId = dto.IeltsExamParticipantId;
            QuestionId = dto.QuestionId;
            AnswerId = dto.AnswerId;
            AnswerTextSetter(dto.AnswerText);
            CustomerId = dto.CustomerId;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }
        
        public Guid ReadingExamId { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid? AnswerId { get; set; }
        public string AnswerText { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public void AnswerTextSetter(string answerText)
        {
            if (answerText != null)
            {
                if (answerText.Length > ReadingContextExceptionBoundaries.ReadingAnswerTextMAXLength)
                {
                    throw new TitleIsMoreThanMaxLenghException();
                }
            }
            this.AnswerText = answerText;
        }

        public IEnumerable<Expression<Func<ReadingUserAnswer, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
