using Framework.Core.Application;
using Framework.Core.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public class CommandBus : ICommandBus
    {
        private readonly IDiContainer diContainer;
        public CommandBus(IDiContainer diContainer)
        {
            this.diContainer = diContainer;
        }
        public void Dispatch<TCommand>(TCommand command) where TCommand : Command
        {
            try
            {
                var commandHandler = diContainer.Resolve<ICommandHandler<TCommand>>();
                var transactionalCommandHandler = new TransactionalCommandHandler<TCommand>(commandHandler, diContainer);
                var logCommandHandler = new LogCommandHandler<TCommand>(transactionalCommandHandler);
                logCommandHandler.Execute(command);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
