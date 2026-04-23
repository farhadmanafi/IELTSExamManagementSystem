using ExamContext.Ielts.Aplication.Contracts.ParticipantsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Facade.Contracts.ParticipantsAggregate
{
    public interface IIeltsExamParticipantsDetailFacade
    {
        void AddIeltsExamParticipantsDetail(AddIeltsExamParticipantsDetailCommand command);
        void UpdateIeltsExamParticipantsDetail(UpdateIeltsExamParticipantsDetailCommand command);
        //void DeleteIeltsExamParticipantsDetail(DeleteIeltsExamParticipantsDetailCommand command);
    }
}
