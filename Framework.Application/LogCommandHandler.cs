using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public class LogCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : Command
    {
        private readonly ICommandHandler<TCommand> commandHandler;

        public LogCommandHandler(ICommandHandler<TCommand> commandHandler)
        {
            this.commandHandler = commandHandler;
        }
        public void Execute(TCommand command)
        {
            commandHandler.Execute(command);
        }
    }
}
