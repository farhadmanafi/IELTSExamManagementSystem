using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Event
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent domainEvent);

        void Subscribe<TEvent>(Action<dynamic> action);
    }
}
