using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Application
{
    public abstract class Command
    {
        protected Command()
        {
            TimeStamp = DateTime.Now;
        }
        public DateTime TimeStamp { get; set; }
    }
}
