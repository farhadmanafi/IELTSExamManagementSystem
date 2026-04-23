using ExamContext.Listening.Domain.Contracts.ListeningExamAggregate;
using ExamContext.Listening.Domain.ListeningExamAggregate.Exceptions;
using Framework.Core.Domain;
using Framework.Domain;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.ListeningExamAggregate
{
    public class ListeningExam : EntityBase, IAggregateRoot<ListeningExam>
    {
        public ListeningExam()
        {

        }
        public ListeningExam(ListeningExamDto dto)
        {

            IeltsExamId = dto.IeltsExamId;
            TitleSetter(dto.Title);
            DescriptionSetter(dto.Description);
            PreVoiceSource = dto.PreVoiceSource;
            VoiceSource = dto.VoiceSource;
            TimerMinutiesSetter(dto.TimerMinuties);
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }       

        public Guid IeltsExamId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PreVoiceSource { get; set; }
        public string VoiceSource { get; set; }
        public int? TimerMinuties { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<ListeningExamSection> ListeningExamSectionList { get; set; }

        public void TimerMinutiesSetter(int? timerMinuties)
        {
            if (timerMinuties != null) {
                if (timerMinuties > ListeningContextExceptionBoundaries.TimerMinutiesMAX
                    | timerMinuties < ListeningContextExceptionBoundaries.TimerMinutiesMIN)
                {
                    throw new TimerExceededValidLengthException();
                }
            }
            this.TimerMinuties = timerMinuties;
        }

        public void TitleSetter(string title)
        {
            if (title.Length > ListeningContextExceptionBoundaries.ListeningExamTitleMAXLength)
            {
                throw new TitleIsMoreThanMaxLenghException();
            }
            this.Title = title;
        }
        public void DescriptionSetter(string description)
        {
            if (description.Length > ListeningContextExceptionBoundaries.ListeningExamDescriptionMAXLength)
            {
                throw new DescriptionIsMoreThanMaxLenghException();
            }
            this.Description = description;
        }

        public IEnumerable<Expression<Func<ListeningExam, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
