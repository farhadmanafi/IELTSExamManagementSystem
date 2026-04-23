using ExamContext.Listening.Aplication.Contracts.ListeningQuestionAggregate;
using ExamContext.Listening.Domain.Contracts.ListeningQuestionAggregate;
using ExamContext.Listening.Domain.ListeningQuestionAggregate;
using ExamContext.Listening.Domain.ListeningQuestionAggregate.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Aplication.ListeningQuestionAggregate
{
    public class UpdateListeningQuestionCommandHandler : ICommandHandler<UpdateListeningQuestionCommand>
    {
        private readonly IListeningQuestionRepository listeningQuestionRepository;
        public UpdateListeningQuestionCommandHandler(IListeningQuestionRepository listeningQuestionRepository)
        {
            this.listeningQuestionRepository = listeningQuestionRepository;
        }
        public void Execute(UpdateListeningQuestionCommand command)
        {
            var ListeningQuestion = listeningQuestionRepository.GetListeningQuestion(command.Id);
            //Changest
            ListeningQuestion.TitleSetter(command.Title);
            ListeningQuestion.DescriptionSetter(command.Description);
            ListeningQuestion.ListeningExamSectionId = command.ListeningExamSectionId;
            ListeningQuestion.ListeningQuestionTypeId = command.ListeningQuestionTypeId;
            ListeningQuestion.ListeningExamQuestionBlockId = command.ListeningExamQuestionBlockId;
            ListeningQuestion.OrderNo = command.OrderNo;
            ListeningQuestion.Score = command.Score;
            ListeningQuestion.IsActive = command.IsActive;

            listeningQuestionRepository.UpdateListeningQuestion(ListeningQuestion);
        }
    }
}
