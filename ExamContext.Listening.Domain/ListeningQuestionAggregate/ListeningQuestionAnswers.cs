using ExamContext.Listening.Domain.Contracts.ListeningQuestionAggregate;
using ExamContext.Listening.Domain.ListeningQuestionAggregate.Exceptions;
using Framework.Core.Domain;
using Framework.Domain;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.ListeningQuestionAggregate
{
    public class ListeningQuestionAnswers : EntityBase, IAggregateRoot<ListeningQuestionAnswers>
    {
        public ListeningQuestionAnswers()
        {

        }
        public ListeningQuestionAnswers(ListeningQuestionAnswersDto dto)
        {
            TitleSetter(dto.Title);
            DescriptionSetter(dto.Description);
            OrderNo = dto.OrderNo;
            IsCorrect = dto.IsCorrect;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
            ListeningQuestionId = dto.ListeningQuestionId;
        }
               

        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid ListeningQuestionId { get; set; }
        [ForeignKey("ListeningQuestionId")]
        public ListeningQuestion ListeningQuestionCurrent { get; set; }

        public void DescriptionSetter(string description)
        {
            if (description.Length > ListeningContextExceptionBoundaries.ListeningQuestionAnswerDescriptionMAXLength)
            {
                throw new DescriptionIsMoreThanMaxLenghException();
            }
            this.Description = description;
        }

        public void TitleSetter(string title)
        {
            if (title.Length > ListeningContextExceptionBoundaries.ListeningQuestionAnswerTitleMAXLength)
            {
                throw new TitleIsMoreThanMaxLenghException();
            }
            this.Title = title;
        }
        public IEnumerable<System.Linq.Expressions.Expression<Func<ListeningQuestionAnswers, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
