using Framework.DIAssemblyLoader;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.PersistanceDatabase
{
    public class IeltsDBContext : DbContextBase //DbContext, IDbContext
    {
        public IeltsDBContext(DbContextOptions<IeltsDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var workingDirectory = new AssemblyLoader("ExamContext.");
            //var workingDirectory = Path.GetDirectoryName(this.GetType().Assembly.Location);
            var mappings = AssemblyLoader.DiscoverInstances<IEntityMapping>();

            mappings.ToList().ForEach(m => modelBuilder.ApplyConfiguration(m as dynamic));

            base.OnModelCreating(modelBuilder);
        }



    }
}
