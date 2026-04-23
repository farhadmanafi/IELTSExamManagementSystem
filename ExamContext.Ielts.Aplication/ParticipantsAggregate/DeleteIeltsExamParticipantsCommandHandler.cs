using ExamContext.Ielts.Aplication.Contracts.ParticipantsAggregate;
using ExamContext.Ielts.Domain.ParticipantsAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Aplication.ParticipantsAggregate
{
    public class DeleteIeltsExamParticipantsCommandHandler : ICommandHandler<DeleteIeltsExamParticipantsCommand>
    {
        private readonly IIeltsExamParticipantsRepository ieltsExamParticipantsRepository;
        public DeleteIeltsExamParticipantsCommandHandler(IIeltsExamParticipantsRepository ieltsExamParticipantsRepository)
        {
            this.ieltsExamParticipantsRepository = ieltsExamParticipantsRepository;
        }
        public void Execute(DeleteIeltsExamParticipantsCommand command)
        {
            var ieltsExamParticipants = ieltsExamParticipantsRepository.GetIeltsExamParticipants(command.Id);
            ieltsExamParticipants.IsDeleted = true;
            ieltsExamParticipants.IsActive = false;

            ieltsExamParticipantsRepository.UpdateIeltsExamParticipants(ieltsExamParticipants);
        }
    }
}
