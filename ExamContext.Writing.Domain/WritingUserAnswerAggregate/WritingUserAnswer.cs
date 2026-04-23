using ExamContext.Writing.Domain.Contracts.WritingUserContextAggregate;
using Framework.Core.Domain;
using Framework.Domain;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ExamContext.Writing.Domain.WritingUserAnswerAggregate.Exceptions;

namespace ExamContext.Writing.Domain.WritingUserAnswerAggregate
{
    public class WritingUserAnswer : EntityBase, IAggregateRoot<WritingUserAnswer>
    {
        public WritingUserAnswer()
        {

        }
        public WritingUserAnswer(WritingUserAnswerDto dto)
        {
            WritingExamSectionId = dto.WritingExamSectionId;
            IeltsExamParticipantId = dto.IeltsExamParticipantId;
            AnswerTextSetter(dto.AnswerText);
            CustomerId = dto.CustomerId;
            RegisterDateTime = dto.RegisterDateTime;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }
        public Guid WritingExamSectionId { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
        public string AnswerText { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        private void AnswerTextSetter(string answerText)
        {
            if (answerText.Length > WritingContextExceptionBoundaries.WritingAnswerTextMAXLength)
            {
                throw new AnswerIsMoreThanMaxLenghException();
            }
            this.AnswerText = answerText;
        }
        public IEnumerable<Expression<Func<WritingUserAnswer, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
