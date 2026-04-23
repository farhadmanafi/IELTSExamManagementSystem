using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Domain.ParticipantsAggregate.Services
{
    public interface IIeltsExamParticipantsDetailRepository
    {
        void AddIeltsExamParticipantsDetail(IeltsExamParticipantsDetail ieltsExamParticipantsDetail);
        IeltsExamParticipantsDetail GetIeltsExamParticipantsDetail(Guid id);
        void UpdateIeltsExamParticipantsDetail(IeltsExamParticipantsDetail ieltsExamParticipantsDetail);
    }
}
