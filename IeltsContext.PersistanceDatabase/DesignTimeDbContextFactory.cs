using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.PersistanceDatabase
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IeltsDBContext>
    {
        public IeltsDBContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
                   .AddJsonFile("AppSettings.Development.json", true);

            var configuration = configurationBuilder.Build();

            var builder = new DbContextOptionsBuilder<IeltsDBContext>();

            //var connectionString = "Data Source=sql.digihole.ir,1430;Initial Catalog=8416_referenceinsurancedb;User ID=8416_referenceinsuranceuser;Password=Referenceinsurance$1;MultipleActiveResultSets=True;Application Name=EntityFramework"; // configuration.GetConnectionString("DefaultConnection");
            var connectionString = "Data Source=185.88.154.174,1430;Initial Catalog=bpvielt1_bpvieltsdb;User ID=bpvielt1_bpvieltsuser;Password=bpvieltsuser@#2022!;MultipleActiveResultSets=True;Application Name=EntityFramework"; // configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new IeltsDBContext(builder.Options);

        }
    }
}
