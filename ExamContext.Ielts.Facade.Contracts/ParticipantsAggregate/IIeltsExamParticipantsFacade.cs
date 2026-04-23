using ExamContext.Ielts.Aplication.Contracts.ParticipantsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Facade.Contracts.ParticipantsAggregate
{
    public interface IIeltsExamParticipantsFacade
    {
        Guid AddIeltsExamParticipants(AddIeltsExamParticipantsCommand command);
        void UpdateIeltsExamParticipants(UpdateIeltsExamParticipantsCommand command);
        void DeleteIeltsExamParticipants(DeleteIeltsExamParticipantsCommand command);
    }
}
