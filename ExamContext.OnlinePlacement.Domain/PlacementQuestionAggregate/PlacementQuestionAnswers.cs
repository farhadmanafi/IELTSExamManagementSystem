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
    public class PlacementQuestionAnswers : EntityBase, IAggregateRoot<PlacementQuestionAnswers>
    {
        public PlacementQuestionAnswers()
        {

        }
        public PlacementQuestionAnswers(PlacementQuestionAnswersDto dto)
        {
            TitleSetter(dto.Title);
            DescriptionSetter(dto.Description);
            OrderNo = dto.OrderNo;
            PlacementQuestionId = dto.PlacementQuestionId;
            IsCorrect = dto.IsCorrect;
            IsActive = dto.IsActive;
            IsActive = dto.IsActive;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid PlacementQuestionId { get; set; }
        [ForeignKey("PlacementQuestionId")]
        public PlacementQuestion PlacementQuestionCurrent { get; set; }

        public void DescriptionSetter(string description)
        {
            if (description.Length > PlacementContextExceptionBoundaries.PlacementQuestionAnswerDescriptionMAXLength)
            {
                throw new DescriptionIsMoreThanMaxLenghException();
            }
            this.Description = description;
        }

        public void TitleSetter(string title)
        {
            if (title.Length > PlacementContextExceptionBoundaries.PlacementQuestionAnswerTitleMAXLength)
            {
                throw new TitleIsMoreThanMaxLenghException();
            }
            this.Title = title;
        }
        public IEnumerable<Expression<Func<PlacementQuestionAnswers, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
