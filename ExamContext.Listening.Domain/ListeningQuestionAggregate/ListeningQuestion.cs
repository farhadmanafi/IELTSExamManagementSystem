using ExamContext.Listening.Domain.Contracts.ListeningQuestionAggregate;
using ExamContext.Listening.Domain.ListeningQuestionAggregate.Exceptions;
using Framework.Core.Domain;
using Framework.Domain;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.ListeningQuestionAggregate
{
    public class ListeningQuestion : EntityBase, IAggregateRoot<ListeningQuestion>
    {
        public ListeningQuestion()
        {

        }
        public ListeningQuestion(ListeningQuestionDto dto)
        {
            TitleSetter(dto.Title);
            DescriptionSetter(dto.Description);
            ListeningExamId = dto.ListeningExamId;
            ListeningExamSectionId = dto.ListeningExamSectionId;
            ListeningExamQuestionBlockId = dto.ListeningExamQuestionBlockId;
            ListeningExamId = dto.ListeningExamId;
            Score = dto.Score;
            OrderNo = dto.OrderNo;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
            ListeningQuestionTypeId = dto.ListeningQuestionTypeId;
        }

        public Guid ListeningExamId { get; set; }
        public Guid ListeningExamSectionId { get; set; }
        public Guid ListeningExamQuestionBlockId { get; set; }
        public float Score { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid ListeningQuestionTypeId { get; set; }
        [ForeignKey("ListeningQuestionTypeId")]
        public ListeningQuestionType ListeningQuestionTypeCurrent { get; set; }

        public ICollection<ListeningQuestionAnswers> ListeningQuestionAnswersList { get; set; }

        public void DescriptionSetter(string description)
        {
            if (description.Length > ListeningContextExceptionBoundaries.ListeningQuestionDescriptionMAXLength)
            {
                throw new DescriptionIsMoreThanMaxLenghException();
            }
            this.Description = description;
        }

        public void TitleSetter(string title)
        {
            if (title.Length > ListeningContextExceptionBoundaries.ListeningQuestionTitleMAXLength)
            {
                throw new TitleIsMoreThanMaxLenghException();
            }
            this.Title = title;
        }
        public IEnumerable<Expression<Func<ListeningQuestion, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
