using ExamContext.Reading.Domain.Contracts.ReadingQuestionAggregate;
using ExamContext.Reading.Domain.ReadingQuestionAggregate.Exceptions;
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

namespace ExamContext.Reading.Domain.ReadingQuestionAggregate
{
    public class ReadingQuestion : EntityBase, IAggregateRoot<ReadingQuestion>
    {
        public ReadingQuestion()
        {

        }
        public ReadingQuestion(ReadingQuestionDto dto)
        {
            TitleSetter(dto.Title);
            DescriptionSetter(dto.Description);
            ReadingExamId = dto.ReadingExamId;
            ReadingExamSectionId = dto.ReadingExamSectionId;
            ReadingExamQuestionBlockId = dto.ReadingExamQuestionBlockId;
            ReadingExamId = dto.ReadingExamId;
            Score = dto.Score;
            OrderNo = dto.OrderNo;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
            ReadingQuestionTypeId = dto.ReadingQuestionTypeId;
        }

        public Guid ReadingExamId { get; set; }
        public Guid ReadingExamSectionId { get; set; }
        public Guid ReadingExamQuestionBlockId { get; set; }
        public float Score { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid ReadingQuestionTypeId { get; set; }
        [ForeignKey("ReadingQuestionTypeId")]
        public ReadingQuestionType ReadingQuestionTypeCurrent { get; set; }

        public ICollection<ReadingQuestionAnswers> ReadingQuestionAnswersList { get; set; }

        public void DescriptionSetter(string description)
        {
            if (description.Length > ReadingContextExceptionBoundaries.ReadingQuestionDescriptionMAXLength)
            {
                throw new DescriptionIsMoreThanMaxLenghException();
            }
            this.Description = description;
        }

        public void TitleSetter(string title)
        {
            if (title.Length > ReadingContextExceptionBoundaries.ReadingQuestionTitleMAXLength)
            {
                throw new TitleIsMoreThanMaxLenghException();
            }
            this.Title = title;
        }

        public IEnumerable<Expression<Func<ReadingQuestion, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
