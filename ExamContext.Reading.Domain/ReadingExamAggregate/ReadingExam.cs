using ExamContext.Reading.Domain.Contracts.ReadingExamAggregate;
using Framework.Core.Domain;
using Framework.Domain;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamContext.Reading.Domain.ReadingExamAggregate.Exceptions;

namespace ExamContext.Reading.Domain.ReadingExamAggregate
{
    public class ReadingExam : EntityBase, IAggregateRoot<ReadingExam>
    {
        public ReadingExam()
        {

        }
        public ReadingExam(ReadingExamDto dto)
        {
            IeltsExamId = dto.IeltsExamId;
            TitleSetter(dto.Title);
            TimerMinutiesSetter(dto.TimerMinuties);
            DescriptionSetter(dto.Description);
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }             

        public Guid IeltsExamId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TimerMinuties { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<ReadingExamSection> ReadingExamSectionList { get; set; }

        public void TitleSetter(string title)
        {
            if (title.Length > ReadingContextExceptionBoundaries.ReadingExamTitleMAXLength)
            {
                throw new TitleIsMoreThanMaxLenghException();
            }
            this.Title = title;
        }
        public void TimerMinutiesSetter(int? timerMinuties)
        {
            if (timerMinuties != null) {
                if (timerMinuties > ReadingContextExceptionBoundaries.TimerMinutiesMAX
                | timerMinuties < ReadingContextExceptionBoundaries.TimerMinutiesMIN)
                {
                    throw new TimerExceededValidLengthException();
                }
            }
            this.TimerMinuties = timerMinuties;
        }
        public void DescriptionSetter(string description)
        {
            if (description.Length > ReadingContextExceptionBoundaries.ReadingExamDescriptionMAXLength)
            {
                throw new DescriptionIsMoreThanMaxLenghException();
            }
            this.Description = description;
        }

        public IEnumerable<System.Linq.Expressions.Expression<Func<ReadingExam, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
