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
    public class UpdatePlacementQuestionCommandHandler : ICommandHandler<UpdatePlacementQuestionCommand>
    {
        private readonly IPlacementQuestionRepository _iPlacementQuestionRepository;
        public UpdatePlacementQuestionCommandHandler(IPlacementQuestionRepository iPlacementQuestionRepository)
        {
            _iPlacementQuestionRepository = iPlacementQuestionRepository;
        }
        public void Execute(UpdatePlacementQuestionCommand command)
        {
            var PlacementQuestion = _iPlacementQuestionRepository.GetPlacementQuestion(command.Id);
            //Changest
            PlacementQuestion.TitleSetter(command.Title);
            PlacementQuestion.DescriptionSetter(command.Description);
            PlacementQuestion.OrderNo = command.OrderNo;
            PlacementQuestion.PlacementQuestionTypeId = command.PlacementQuestionTypeId;
            PlacementQuestion.IsActive = command.IsActive;

            _iPlacementQuestionRepository.UpdatePlacementQuestion(PlacementQuestion);
        }
    }
}
