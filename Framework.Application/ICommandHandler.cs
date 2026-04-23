using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public interface ICommandHandler<in TCommand> where TCommand : Command
    {
        void Execute(TCommand command);
    }
}
