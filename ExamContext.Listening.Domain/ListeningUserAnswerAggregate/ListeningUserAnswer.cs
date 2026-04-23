using ExamContext.Listening.Domain.Contracts.ListeningUserAnswerAggregate;
using ExamContext.Listening.Domain.ListeningUserAnswerAggregate.Exceptions;
using Framework.Core.Domain;
using Framework.Domain;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.ListeningUserAnswerAggregate
{
    public class ListeningUserAnswer : EntityBase, IAggregateRoot<ListeningUserAnswer>
    {
        public ListeningUserAnswer()
        {

        }
        public ListeningUserAnswer(ListeningUserAnswerDto dto)
        {
            ListeningExamId = dto.ListeningExamId;
            IeltsExamParticipantId = dto.IeltsExamParticipantId;
            QuestionId = dto.QuestionId;
            AnswerId = dto.AnswerId;
            AnswerTextSetter(dto.AnswerText);
            CustomerId = dto.CustomerId;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }        

        public Guid ListeningExamId { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid? AnswerId { get; set; }
        public string AnswerText { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        private void AnswerTextSetter(string answerText)
        {
            if (answerText != null)
            {
                if (answerText.Length > ListeningContextExceptionBoundaries.ListeningAnswerTextMAXLength)
                {
                    throw new AnswerIsMoreThanMaxLenghException();
                }
            }
            this.AnswerText = answerText;
        }

        public IEnumerable<Expression<Func<ListeningUserAnswer, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
