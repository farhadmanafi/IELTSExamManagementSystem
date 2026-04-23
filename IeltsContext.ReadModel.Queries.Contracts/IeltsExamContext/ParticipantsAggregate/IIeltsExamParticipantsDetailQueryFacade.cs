using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate.DataContracts;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate
{
    public interface IIeltsExamParticipantsDetailQueryFacade : IQueryFacade
    {
        IeltsExamParticipantsDetailQueryFacadeDto GetIeltsExamParticipantsDetailById(Guid id);
        IeltsExamParticipantsDetailQueryFacadeDto GetIeltsExamParticipantsDetailByIeltsExamParticipantsId(Guid ieltsExamParticipantsId);

    }
}
