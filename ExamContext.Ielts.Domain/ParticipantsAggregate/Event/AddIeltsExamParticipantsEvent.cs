using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Domain.ParticipantsAggregate.Event
{
    public class AddIeltsExamParticipantsEvent
    {
        public AddIeltsExamParticipantsEvent(Guid? id)
        {
            Id = id;
        }
        public Guid? Id { get; private set; }
    }
}
