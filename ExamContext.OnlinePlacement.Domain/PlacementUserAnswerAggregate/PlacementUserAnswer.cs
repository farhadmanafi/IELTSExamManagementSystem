using ExamContext.OnlinePlacement.Domain.Contracts.PlacementUserAnswerAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementUserAnswerAggregate.Exceptions;
using Framework.Core.Domain;
using Framework.Domain;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.PlacementUserAnswerAggregate
{
    public class PlacementUserAnswer : EntityBase, IAggregateRoot<PlacementUserAnswer>
    {
        public PlacementUserAnswer()
        {

        }
        public PlacementUserAnswer(PlacementUserAnswerDto dto)
        {
            IeltsExamId = dto.IeltsExamId;
            PlacementUserScoreId = dto.PlacementUserScoreId;
            QuestionId = dto.QuestionId;
            AnswerId = dto.AnswerId;
            AnswerTextSetter(dto.AnswerText, dto.AnswerId);
            CustomerId = dto.CustomerId;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }

        public void AnswerTextSetter(string answerText, Guid? answerId)
        {
            if (AnswerText != null)
            {
                if (answerText.Length > PlacementContextExceptionBoundaries.PlacementAnswerTextMAXLength)
                {
                    throw new AnswerIsMoreThanMaxLenghException();
                }
            }
            this.AnswerText = answerText;
        }

        public Guid IeltsExamId { get; set; }
        public Guid PlacementUserScoreId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid? AnswerId { get; set; }
        public string AnswerText { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public IEnumerable<Expression<Func<PlacementUserAnswer, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
