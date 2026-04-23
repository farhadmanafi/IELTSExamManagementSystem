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
    public class PlacementExamPriceFacade : FacadeCommandBase, IPlacementExamPriceFacade
    {
        public PlacementExamPriceFacade(ICommandBus commandBus) : base(commandBus)
        {

        }
        public void AddPlacementExamPrice(AddPlacementExamPriceCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
