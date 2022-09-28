using Duende.IdentityServer.EntityFramework.Options;
using ERP.XCore.Data.Base;
using ERP.XCore.Entities.Base;
using ERP.XCore.Entities.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Data.Context
{
    public class ApplicationDbContext 
        : ApplicationApiAuthorizationDbContext<ApplicationUser, ApplicationRole, Guid, IdentityUserClaim<Guid>, ApplicationUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<CompanyHeadquarter> CompanyHeadquarters { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<PersonType> PersonTypes { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<PermissionLevel> PermissionLevels { get; set; }

        public DbSet<PointOfSale> PointsOfSale { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomStatus> RoomStatus { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

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

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => (e.Entity is BaseEntity || e.Entity is ApplicationUser) && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.Entity is BaseEntity)
                {
                    ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;

                    if (entityEntry.State == EntityState.Added)
                    {
                        ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                    }
                }
                else
                {
                    //((ApplicationUser)entityEntry.Entity).UpdatedAt = DateTime.Now;

                    //if (entityEntry.State == EntityState.Added)
                    //{
                    //    ((ApplicationUser)entityEntry.Entity).CreatedAt = DateTime.Now;
                    //}
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
