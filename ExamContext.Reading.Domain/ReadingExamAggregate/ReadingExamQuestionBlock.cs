using ExamContext.Reading.Domain.Contracts.ReadingExamAggregate;
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

namespace ExamContext.Reading.Domain.ReadingExamAggregate
{
    public class ReadingExamQuestionBlock : EntityBase, IAggregateRoot<ReadingExamQuestionBlock>
    {
        public ReadingExamQuestionBlock()
        {

        }
        public ReadingExamQuestionBlock(ReadingExamQuestionBlockDto dto)
        {
            ReadingExamSectionId = dto.ReadingExamSectionId;
            TitleSetter(dto.Title);
            OrderNo = dto.OrderNo;
            DescriptionSetter(dto.Description);
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }
        
        public Guid ReadingExamSectionId { get; set; }
        [ForeignKey("ReadingExamSectionId")]
        public ReadingExamSection CurrentReadingExamSection { get; set; }

        public string Title { get; set; }
        public int OrderNo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public void DescriptionSetter(string description)
        {
            if (description.Length > ReadingContextExceptionBoundaries.ReadingQuestionBlockDescriptionMAXLength)
            {
                throw new DescriptionIsMoreThanMaxLenghException();
            }
            this.Description = description;
        }

        public void TitleSetter(string title)
        {
            if (title.Length > ReadingContextExceptionBoundaries.ReadingQuestionBlockTitleMAXLength)
            {
                throw new TitleIsMoreThanMaxLenghException();
            }
            this.Title = title;
        }
        public IEnumerable<System.Linq.Expressions.Expression<Func<ReadingExamQuestionBlock, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
