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
    public class DeletePlacementQuestionAnswersCommandHandler : ICommandHandler<DeletePlacementQuestionCommand>
    {
        private readonly IPlacementQuestionAnswersRepository _iPlacementQuestionAnswersRepository;
        public DeletePlacementQuestionAnswersCommandHandler(IPlacementQuestionAnswersRepository iPlacementQuestionAnswersRepository)
        {
            _iPlacementQuestionAnswersRepository = iPlacementQuestionAnswersRepository;
        }
        public void Execute(DeletePlacementQuestionCommand command)
        {
            var PlacementQuestionAnswers = _iPlacementQuestionAnswersRepository.GetPlacementQuestionAnswers(command.Id);
            PlacementQuestionAnswers.IsDeleted = true;
            PlacementQuestionAnswers.IsActive = false;

            _iPlacementQuestionAnswersRepository.UpdatePlacementQuestionAnswers(PlacementQuestionAnswers);
        }
    }
}
