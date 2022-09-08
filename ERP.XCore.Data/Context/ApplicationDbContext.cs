using Duende.IdentityServer.EntityFramework.Options;
using ERP.XCore.Entities.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Data.Context
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<CompanyHeadquarter> CompanyHeadquarters { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<PermissionLevel> PermissionLevels { get; set; }

        public DbSet<PointOfSale> PointsOfSale { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<SubModule> SubModules { get; set; }

        public DbSet<Ubigeo> Ubigeos { get; set; }

        public DbSet<WorkArea> WorkAreas { get; set; }

        public DbSet<WorkPosition> WorkPositions { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
