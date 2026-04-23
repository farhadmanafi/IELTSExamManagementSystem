using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Event
{
    public class EventHandler
    {
        public EventHandler(Action<object> handlingAction)
        {
            this.Action = handlingAction;
        }

        public Action<object> Action { get; }
    }
}
