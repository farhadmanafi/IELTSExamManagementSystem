using ExamContext.Speaking.Domain.Contracts.SpeakingExamAggregate;
using ExamContext.Speaking.Domain.SpeakingExamAggregate.Exceptions;
using Framework.Core.Domain;
using Framework.Domain;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Domain.SpeakingExamAggregate
{
    public class SpeakingExam : EntityBase, IAggregateRoot<SpeakingExam>
    {
        public SpeakingExam()
        {

        }
        public SpeakingExam(SpeakingExamDto dto)
        {
            IeltsExamId = dto.IeltsExamId;
            TitleSetter(dto.Title);
            DescriptionSetter(dto.Description);
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }             

        public Guid IeltsExamId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public void TitleSetter(string title)
        {
            if (title.Length > SpeakingContextExceptionBoundaries.SpeakingExamTitleMAXLength)
            {
                throw new TitleIsMoreThanMaxLenghException();
            }
            this.Title = title;
        }
        public void DescriptionSetter(string description)
        {
            if (description.Length > WritingContextExceptionBoundaries.WritingExamDescriptionMAXLength)
            {
                throw new DescriptionIsMoreThanMaxLenghException();
            }
            this.Description = description;
        }

        public IEnumerable<Expression<Func<SpeakingExam, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
