using Framework.Core.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DependencyInjection
{
    public class DiContainer : IDiContainer
    {
        private readonly IServiceProvider container;

        public DiContainer(IServiceProvider container)
        {
            this.container = container;
        }

        public T Resolve<T>()
        {
            return (T)this.container.GetService(typeof(T));
            //return container.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            //baresi shavad----------------
            return (IEnumerable<T>)this.container.GetService(typeof(T));
            //return container.ResolveAll<T>();
        }
    }
}
