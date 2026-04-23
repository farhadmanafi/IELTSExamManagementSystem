using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamContext.Reading.Domain.Contracts.ReadingExamAggregate;
using ExamContext.Reading.Domain.ReadingExamAggregate.Exceptions;
using Framework.Core.Domain;
using Framework.Domain;
using Ielts.Common.GeneralClass;

namespace ExamContext.Reading.Domain.ReadingExamAggregate
{
    public class ReadingExamSection : EntityBase, IAggregateRoot<ReadingExamSection>
    {
        public ReadingExamSection()
        {

        }
        public ReadingExamSection(ReadingExamSectionDto dto)
        {
            TitleSetter(dto.Title);
            DescriptionSetter(dto.Description);
            ReadingText = dto.ReadingText;;
            OrderNo = dto.OrderNo;
            ReadingExamId = dto.ReadingExamId;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }

        public Guid ReadingExamId { get; set; }
        [ForeignKey("ReadingExamId")]
        public ReadingExam CurrentReadingExam { get; set; }

        public ICollection<ReadingExamQuestionBlock> ReadingExamQuestionBlockList { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReadingText { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public void TitleSetter(string title)
        {
            if (title.Length > ReadingContextExceptionBoundaries.ReadingExamSectionTitleMAXLength)
            {
                throw new TitleIsMoreThanMaxLenghException();
            }
            this.Title = title;
        }
        public void DescriptionSetter(string description)
        {
            if (description.Length > ReadingContextExceptionBoundaries.ReadingExamDescriptionMAXLength)
            {
                throw new DescriptionIsMoreThanMaxLenghException();
            }
            this.Description = description;
        }

        public IEnumerable<System.Linq.Expressions.Expression<Func<ReadingExamSection, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
