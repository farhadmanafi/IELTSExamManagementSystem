using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementExamAggregate;
using ExamContext.OnlinePlacement.Facade.Contracts.PlacementExamAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Facade.PlacementExamAggregate
{
    public class PlacementExamFacade : FacadeCommandBase, IPlacementExamFacade
    {
        public PlacementExamFacade(ICommandBus commandBus) : base(commandBus)
        {

        }
        public void AddPlacementExam(AddPlacementExamCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeletePlacementExam(DeletePlacementExamCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdatePlacementExam(UpdatePlacementExamCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
