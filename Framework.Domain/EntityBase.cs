using Framework.Core.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public abstract class EntityBase : EventBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
            TimeStamp = DateTime.Now;
            //IsActive = true;
            //IsDeleted = false;
        }
        //protected EntityBase(IDiContainer diContainer) : base(diContainer)
        //{
        //    Id = Guid.NewGuid();
        //    TimeStamp = DateTime.Now;
        //}      

        public Guid Id { get; private set; }
        public DateTime TimeStamp { get; private set; }
        //public bool IsActive { get; set; }
        //public bool IsDeleted { get; set; }

    }
}
