using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Data.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContextFactory()
        {
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            builder.UseSqlServer(
                //DataConnectionString
                //"Server=(localdb)\\mssqllocaldb;Database=aspnet-ERP.XCore.Hotel.Web.Server-36CFA546-D67D-4BE7-B733-3FFF351E9E26;Trusted_Connection=True;MultipleActiveResultSets=true",
                "Server=localhost;Database=ERP.XCORE.DB;Trusted_Connection=True;MultipleActiveResultSets=true",
                //"Server=HRNBK00977\\MSSQLSERVER01;Database=ERP.XCORE.DB;Trusted_Connection=True;MultipleActiveResultSets=true",
                opts =>
                {
                    opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                });

            return new ApplicationDbContext(builder.Options, new OperationalStoreOptionsMigrations());
        }
    }
}
