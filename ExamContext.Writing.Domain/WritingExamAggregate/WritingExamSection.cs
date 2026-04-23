using ExamContext.Writing.Domain.Contracts.WritingExamAggregate;
using ExamContext.Writing.Domain.WritingExamAggregate.Exceptions;
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

namespace ExamContext.Writing.Domain.WritingExamAggregate
{
    public class WritingExamSection : EntityBase, IAggregateRoot<WritingExamSection>
    {
        public WritingExamSection()
        {
                
        }
        public WritingExamSection(WritingExamSectionDto dto)
        {
            WritingExamId = dto.WritingExamId;
            TitleSetter(dto.Title); 
            TimerMinutiesSetter(dto.TimerMinuties);
            WritingTopicSetter(dto.WritingTopic);
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }
        public Guid WritingExamId { get; set; }
        [ForeignKey("WritingExamId")]
        public WritingExam CurrentWritingExam { get; set; }

        public string Title { get; set; }
        public string WritingTopic { get; set; }
        public int? TimerMinuties { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public void TitleSetter(string title)
        {
            if (title.Length > WritingContextExceptionBoundaries.WritingExamSectionTitleMAXLength)
            {
                throw new TitleIsMoreThanMaxLenghException();
            }
            this.Title = title;
        }
        public void WritingTopicSetter(string writingTopic)
        {
            //if (title.Length > WritingContextExceptionBoundaries.WritingExamSectionTitleMAXLength)
            //{
            //    throw new TitleIsMoreThanMaxLenghException();
            //}
            this.WritingTopic = writingTopic;
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

        public IEnumerable<Expression<Func<WritingExamSection, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
