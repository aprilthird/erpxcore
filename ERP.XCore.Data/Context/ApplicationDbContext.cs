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
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Data.Context
{
    public class ApplicationDbContext 
        : ApplicationApiAuthorizationDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {

        public DbSet<BookingFee> BookingFees { get; set; }

        public DbSet<CashRegister> CashRegisters { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<CompanyHeadquarter> CompanyHeadquarters { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Fee> Fees { get; set; }

        public DbSet<FeeType> FeeTypes { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<PersonType> PersonTypes { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<PermissionLevel> PermissionLevels { get; set; }

        public DbSet<PointOfSale> PointsOfSale { get; set; }

        public DbSet<RoomCheckIn> RoomCheckIns { get; set; }

        public DbSet<RoomCheckInDetail> RoomCheckInDetails { get; set; }

        public DbSet<RoomCleaning> RoomCleanings { get; set; }

        public DbSet<RoomCheckInCompanion> RoomCheckInCompanions { get; set; }

        public DbSet<RoomMaintenance> RoomMaintenances { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoomCheckIn>(b => b.ToTable("RoomBookings"));
            modelBuilder.Entity<RoomCheckInCompanion>(b => b.ToTable("RoomBookingCompanions"));
            modelBuilder.Entity<RoomCheckInDetail>(b => b.ToTable("RoomBookingDetails"));

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });


            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
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
