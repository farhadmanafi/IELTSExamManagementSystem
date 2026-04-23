using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persistence
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
    }
}
