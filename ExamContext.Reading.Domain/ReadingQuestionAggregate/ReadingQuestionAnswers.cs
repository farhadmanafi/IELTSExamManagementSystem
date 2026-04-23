using ExamContext.Reading.Domain.Contracts.ReadingQuestionAggregate;
using ExamContext.Reading.Domain.ReadingExamAggregate.Exceptions;
using Framework.Core.Domain;
using Framework.Domain;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Domain.ReadingQuestionAggregate
{
    public class ReadingQuestionAnswers : EntityBase, IAggregateRoot<ReadingQuestionAnswers>
    {
        public ReadingQuestionAnswers()
        {

        }
        public ReadingQuestionAnswers(ReadingQuestionAnswersDto dto)
        {
            TitleSetter(dto.Title);
            DescriptionSetter(dto.Description);
            OrderNo = dto.OrderNo;
            IsCorrect = dto.IsCorrect;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
            ReadingQuestionId = dto.ReadingQuestionId;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid ReadingQuestionId { get; set; }
        [ForeignKey("ReadingQuestionId")]
        public ReadingQuestion ReadingQuestionCurrent { get; set; }

        public void DescriptionSetter(string description)
        {
            if (description.Length > ReadingContextExceptionBoundaries.ReadingQuestionAnswerDescriptionMAXLength)
            {
                throw new DescriptionIsMoreThanMaxLenghException();
            }
            this.Description = description;
        }

        public void TitleSetter(string title)
        {
            if (title.Length > ReadingContextExceptionBoundaries.ReadingQuestionAnswerTitleMAXLength)
            {
                throw new TitleIsMoreThanMaxLenghException();
            }
            this.Title = title;
        }

        public IEnumerable<System.Linq.Expressions.Expression<Func<ReadingQuestionAnswers, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
