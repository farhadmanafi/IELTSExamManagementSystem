using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Domain.ParticipantsAggregate.Services
{
    public interface IIeltsExamParticipantsRepository
    {
        void AddIeltsExamParticipants(IeltsExamParticipants ieltsExamParticipants);
        IeltsExamParticipants GetIeltsExamParticipants(Guid id);
        void UpdateIeltsExamParticipants(IeltsExamParticipants ieltsExamParticipants);
    }
}
