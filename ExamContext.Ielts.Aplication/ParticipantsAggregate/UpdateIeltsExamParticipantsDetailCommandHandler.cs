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
    public class UpdateIeltsExamParticipantsDetailCommandHandler : ICommandHandler<UpdateIeltsExamParticipantsDetailCommand>
    {
        private readonly IIeltsExamParticipantsDetailRepository iIeltsExamParticipantsDetailRepository;
        public UpdateIeltsExamParticipantsDetailCommandHandler(IIeltsExamParticipantsDetailRepository iIeltsExamParticipantsDetailRepository)
        {
            this.iIeltsExamParticipantsDetailRepository = iIeltsExamParticipantsDetailRepository;
        }
        public void Execute(UpdateIeltsExamParticipantsDetailCommand command)
        {
            var ieltsExamParticipantsDetail = iIeltsExamParticipantsDetailRepository.GetIeltsExamParticipantsDetail(command.Id);
            //Changest

            if(command.ListeningExamIsGive != null)
                ieltsExamParticipantsDetail.ListeningExamIsGive = command.ListeningExamIsGive;
            if (command.ListeningExamStartDateTime != null)
                ieltsExamParticipantsDetail.ListeningExamStartDateTime = command.ListeningExamStartDateTime;
            if (command.ListeningExamEndDateTime != null)
                ieltsExamParticipantsDetail.ListeningExamEndDateTime = command.ListeningExamEndDateTime;
            if (command.ListeningExamRegisterDateTime != null)
                ieltsExamParticipantsDetail.ListeningExamRegisterDateTime = command.ListeningExamRegisterDateTime;
            //-----------------
            if (command.ReadingExamIsGive != null)
                ieltsExamParticipantsDetail.ReadingExamIsGive = command.ReadingExamIsGive;
            if (command.ReadingExamStartDateTime != null)
                ieltsExamParticipantsDetail.ReadingExamStartDateTime = command.ReadingExamStartDateTime;
            if (command.ReadingExamEndDateTime != null)
                ieltsExamParticipantsDetail.ReadingExamEndDateTime = command.ReadingExamEndDateTime;
            if (command.ReadingExamRegisterDateTime != null)
                ieltsExamParticipantsDetail.ReadingExamRegisterDateTime = command.ReadingExamRegisterDateTime;
            //-----------------
            if (command.WritingExamIsGive != null)
                ieltsExamParticipantsDetail.WritingExamIsGive = command.WritingExamIsGive;
            if (command.WritingExamStartDateTime != null)
                ieltsExamParticipantsDetail.WritingExamStartDateTime = command.WritingExamStartDateTime;
            if (command.WritingExamEndDateTime != null)
                ieltsExamParticipantsDetail.WritingExamEndDateTime = command.WritingExamEndDateTime;
            if (command.WritingExamRegisterDateTime != null)
                ieltsExamParticipantsDetail.WritingExamRegisterDateTime = command.WritingExamRegisterDateTime;
            //-----------------
            if (command.SpeakingExamIsSetSession != null)
                ieltsExamParticipantsDetail.SpeakingExamIsSetSession = command.SpeakingExamIsSetSession;

            iIeltsExamParticipantsDetailRepository.UpdateIeltsExamParticipantsDetail(ieltsExamParticipantsDetail);
        }
    }
}
