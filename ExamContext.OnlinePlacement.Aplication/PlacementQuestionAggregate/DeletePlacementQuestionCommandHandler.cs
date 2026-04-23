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
    public class DeletePlacementQuestionCommandHandler : ICommandHandler<DeletePlacementQuestionCommand>
    {
        private readonly IPlacementQuestionRepository _iPlacementQuestionRepository;
        public DeletePlacementQuestionCommandHandler(IPlacementQuestionRepository iPlacementQuestionRepository)
        {
            _iPlacementQuestionRepository = iPlacementQuestionRepository;
        }
        public void Execute(DeletePlacementQuestionCommand command)
        {
            var PlacementQuestion = _iPlacementQuestionRepository.GetPlacementQuestion(command.Id);
            PlacementQuestion.IsDeleted = true;
            PlacementQuestion.IsActive = false;

            _iPlacementQuestionRepository.UpdatePlacementQuestion(PlacementQuestion);
        }
    }
}
