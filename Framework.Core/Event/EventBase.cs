using Framework.Core.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Event
{
    public abstract class EventBase
    {
        protected IEventBus EventBus => ServiceLocator.Current.GetInstance<IEventBus>();
    }
}
