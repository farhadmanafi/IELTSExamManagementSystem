using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.PersistanceDatabase
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext context;

        public UnitOfWork(IDbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Rollback()
        {
            context.Dispose(); // TODO : Better design
        }
    }
}
