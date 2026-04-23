using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Event
{
    internal class EventSubscriptionItem
    {
        public Type EventType { get; set; }

        public IList<EventHandler> Handlers { get; set; }
    }
}
