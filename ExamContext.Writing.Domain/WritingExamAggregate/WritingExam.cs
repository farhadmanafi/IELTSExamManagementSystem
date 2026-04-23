using ExamContext.Writing.Domain.Contracts.WritingExamAggregate;
using ExamContext.Writing.Domain.WritingExamAggregate.Exceptions;
using Framework.Core.Domain;
using Framework.Domain;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Domain.WritingExamAggregate
{
    public class WritingExam : EntityBase, IAggregateRoot<WritingExam>
    {
        public WritingExam()
        {

        }
        public WritingExam(WritingExamDto dto)
        {
            IeltsExamId = dto.IeltsExamId;
            TitleSetter(dto.Title);
            DescriptionSetter(dto.Description);
            TimerMinutiesSetter(dto.TimerMinuties);
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }
        

        public Guid IeltsExamId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TimerMinuties { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<WritingExamSection> WritingExamSectionList { get; set; }
        public void TitleSetter(string title)
        {
            if (title.Length > WritingContextExceptionBoundaries.WritingExamTitleMAXLength)
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
        public void TimerMinutiesSetter(int? timerMinuties)
        {
            if (timerMinuties != null)
            {
                if (timerMinuties > ListeningContextExceptionBoundaries.TimerMinutiesMAX
                    | timerMinuties < ListeningContextExceptionBoundaries.TimerMinutiesMIN)
                {
                    throw new TimerExceededValidLengthException();
                }
            }
            this.TimerMinuties = timerMinuties;
        }
        public IEnumerable<Expression<Func<WritingExam, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
