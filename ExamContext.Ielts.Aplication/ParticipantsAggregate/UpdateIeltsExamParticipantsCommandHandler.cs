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
    public class UpdateIeltsExamParticipantsCommandHandler : ICommandHandler<UpdateIeltsExamParticipantsCommand>
    {
        private readonly IIeltsExamParticipantsRepository ieltsExamParticipantsRepository;
        public UpdateIeltsExamParticipantsCommandHandler(IIeltsExamParticipantsRepository ieltsExamParticipantsRepository)
        {
            this.ieltsExamParticipantsRepository = ieltsExamParticipantsRepository;
        }
        public void Execute(UpdateIeltsExamParticipantsCommand command)
        {
            var ieltsExamParticipants = ieltsExamParticipantsRepository.GetIeltsExamParticipants(command.Id);
            ieltsExamParticipants.IeltsExamParticipantsStatusId = command.IeltsExamParticipantsStatusId;

            ieltsExamParticipantsRepository.UpdateIeltsExamParticipants(ieltsExamParticipants);
        }
    }
}
