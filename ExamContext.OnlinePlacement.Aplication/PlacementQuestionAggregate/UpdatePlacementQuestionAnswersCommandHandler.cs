using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementQuestionAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementQuestionAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Aplication.PlacementQuestionAggregate
{
    public class UpdatePlacementQuestionAnswersCommandHandler : ICommandHandler<UpdatePlacementQuestionAnswersCommand>
    {
        private readonly IPlacementQuestionAnswersRepository _iPlacementQuestionAnswersRepository;
        public UpdatePlacementQuestionAnswersCommandHandler(IPlacementQuestionAnswersRepository iPlacementQuestionAnswersRepository)
        {
            _iPlacementQuestionAnswersRepository = iPlacementQuestionAnswersRepository;
        }
        public void Execute(UpdatePlacementQuestionAnswersCommand command)
        {
            var PlacementQuestionAnswers = _iPlacementQuestionAnswersRepository.GetPlacementQuestionAnswers(command.Id);
            //Changest
            PlacementQuestionAnswers.TitleSetter(command.Title);
            PlacementQuestionAnswers.DescriptionSetter(command.Description);
            PlacementQuestionAnswers.OrderNo = command.OrderNo;
            PlacementQuestionAnswers.IsCorrect = command.IsCorrect;
            PlacementQuestionAnswers.IsActive = command.IsActive;

            _iPlacementQuestionAnswersRepository.UpdatePlacementQuestionAnswers(PlacementQuestionAnswers);
        }
    }
}
