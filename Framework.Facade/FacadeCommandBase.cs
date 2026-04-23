using Framework.Core.Application;
using Framework.Core.DependencyInjection;
using Framework.Core.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Facade
{
    public abstract class FacadeCommandBase
    {
        private readonly IDiContainer diContainer;
        protected FacadeCommandBase(ICommandBus commandBus)
        {
            CommandBus = commandBus;
        }
        //protected FacadeCommandBase(ICommandBus commandBus, IDiContainer diContainer)
        //{
        //    CommandBus = commandBus;
        //    this.diContainer = diContainer;
        //}

        protected ICommandBus CommandBus { get; }
        protected IEventBus EventBus => ServiceLocator.Current.GetInstance<IEventBus>();
        //protected IEventBus EventBus => diContainer.Resolve<IEventBus>();
    }
}
