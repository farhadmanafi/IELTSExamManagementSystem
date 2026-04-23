using ExamContext.Ielts.Aplication.Contracts.ParticipantsAggregate;
using ExamContext.Ielts.Domain.Contracts.ParticipantsAggregate;
using ExamContext.Ielts.Domain.ParticipantsAggregate;
using ExamContext.Ielts.Domain.ParticipantsAggregate.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Aplication.ParticipantsAggregate
{
    public class AddIeltsExamParticipantsCommandHandler : ICommandHandler<AddIeltsExamParticipantsCommand>
    {
        private readonly IIeltsExamParticipantsRepository ieltsExamParticipantsRepository;
        public AddIeltsExamParticipantsCommandHandler(IIeltsExamParticipantsRepository ieltsExamParticipantsRepository)
        {
            this.ieltsExamParticipantsRepository = ieltsExamParticipantsRepository;
        }
        public void Execute(AddIeltsExamParticipantsCommand command)
        {
            var ieltsExamParticipantsDto = Mapper.Map<AddIeltsExamParticipantsCommand, IeltsExamParticipantsDto>(command);
            var ieltsExamParticipants = new IeltsExamParticipants(ieltsExamParticipantsDto);
            if (command.ieltsExamParticipantsDetailDto != null)
            {
                var ieltsExamParticipantsDetail = new IeltsExamParticipantsDetail(command.ieltsExamParticipantsDetailDto);
                ieltsExamParticipants.AddIeltsExamParticipantsDetailDto(ieltsExamParticipantsDetail);
            }

            ieltsExamParticipantsRepository.AddIeltsExamParticipants(ieltsExamParticipants);
        }
    }
}
