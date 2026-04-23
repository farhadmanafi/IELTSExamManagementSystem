using ExamContext.OnlinePlacement.Domain.Contracts.PlacementQuestionAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementQuestionAggregate.Exceptions;
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

namespace ExamContext.OnlinePlacement.Domain.PlacementQuestionAggregate
{
    public class PlacementQuestion : EntityBase, IAggregateRoot<PlacementQuestion>
    {
        public PlacementQuestion()
        {

        }
        public PlacementQuestion(PlacementQuestionDto dto)
        {
            TitleSetter(dto.Title);
            DescriptionSetter(dto.Description);
            OrderNo = dto.OrderNo;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
            PlacementExamtId = dto.PlacementExamtId;
            PlacementQuestionTypeId = dto.PlacementQuestionTypeId;
        }

        public Guid PlacementExamtId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid PlacementQuestionTypeId { get; set; }
        [ForeignKey("PlacementQuestionTypeId")]
        public PlacementQuestionType PlacementQuestionTypeCurrent { get; set; }

        public ICollection<PlacementQuestionAnswers> PlacementQuestionAnswersList { get; set; }

        public void DescriptionSetter(string description)
        {
            if (description.Length > PlacementContextExceptionBoundaries.PlacementQuestionDescriptionMAXLength)
            {
                throw new DescriptionIsMoreThanMaxLenghException();
            }
            this.Description = description;
        }

        public void TitleSetter(string title)
        {
            if (title.Length > PlacementContextExceptionBoundaries.PlacementQuestionTitleMAXLength)
            {
                throw new TitleIsMoreThanMaxLenghException();
            }
            this.Title = title;
        }
        public IEnumerable<Expression<Func<PlacementQuestion, dynamic>>> GetAggregateExpressions()
        {
            yield return c => c.PlacementQuestionAnswersList;
        }
    }
}
