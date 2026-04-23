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
    public class AddIeltsExamParticipantsDetailCommandHandler : ICommandHandler<AddIeltsExamParticipantsDetailCommand>
    {
        private readonly IIeltsExamParticipantsDetailRepository iIeltsExamParticipantsDetailRepository;
        public AddIeltsExamParticipantsDetailCommandHandler(IIeltsExamParticipantsDetailRepository iIIeltsExamParticipantsDetailRepository)
        {
            this.iIeltsExamParticipantsDetailRepository = iIIeltsExamParticipantsDetailRepository;
        }
        public void Execute(AddIeltsExamParticipantsDetailCommand command)
        {
            var ieltsExamParticipantsDetailDto = Mapper.Map<AddIeltsExamParticipantsDetailCommand, IeltsExamParticipantsDetailDto>(command);
            var ieltsExamParticipantsDetail = new IeltsExamParticipantsDetail(ieltsExamParticipantsDetailDto);

            iIeltsExamParticipantsDetailRepository.AddIeltsExamParticipantsDetail(ieltsExamParticipantsDetail);
        }
    }
}
