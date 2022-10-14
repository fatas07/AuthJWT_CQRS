using AuthJWT_CQRS.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthJWT_CQRS.Data.Context
{
    public class AppDbContext : IdentityDbContext<UserEntity>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(Settings.Default.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>()
                    .HasData(
                    new IdentityRole
                    {
                        Id = Settings.Default.RolesAdminRoleId,
                        Name = Settings.Default.RolesAdmin,
                        NormalizedName = Settings.Default.RolesAdmin.ToUpper(new System.Globalization.CultureInfo("en-US")),
                    },
                    new IdentityRole
                    {
                        Id = Settings.Default.RolesSuperuserRoleId,
                        Name = Settings.Default.RolesSuperuser,
                        NormalizedName = Settings.Default.RolesSuperuser.ToUpper(new System.Globalization.CultureInfo("en-US"))
                    },
                    new IdentityRole
                    {
                        Id = Settings.Default.RolesUserRoleId,
                        Name = Settings.Default.RolesUser,
                        NormalizedName = Settings.Default.RolesUser.ToUpper(new System.Globalization.CultureInfo("en-US"))
                    },
                    new IdentityRole
                    {
                        Id = Settings.Default.RolesViewerRoleId,
                        Name = Settings.Default.RolesViewer,
                        NormalizedName = Settings.Default.RolesViewer.ToUpper(new System.Globalization.CultureInfo("en-US"))
                    },
                    new IdentityRole
                    {
                        Id = Settings.Default.RolesGuestRoleId,
                        Name = Settings.Default.RolesGuest,
                        NormalizedName = Settings.Default.RolesGuest.ToUpper(new System.Globalization.CultureInfo("en-US"))
                    },
                    new IdentityRole
                    {
                        Id = Settings.Default.RolesProducerRoleId,
                        Name = Settings.Default.RolesProducer,
                        NormalizedName = Settings.Default.RolesProducer.ToUpper(new System.Globalization.CultureInfo("en-US"))
                    }
                    ); ;

            var hasher = new PasswordHasher<UserEntity>();
            modelBuilder.Entity<UserEntity>()
                .HasData(
                new UserEntity
                {
                    Id = Settings.Default.RolesAdminUserId,
                    Email = Settings.Default.AdminEmail,
                    FirstName = Settings.Default.AdminFirstName,
                    LastName = Settings.Default.AdminLastName,
                    UserName = Settings.Default.AdminEmail,
                    NormalizedUserName = Settings.Default.AdminEmail.ToUpper(new System.Globalization.CultureInfo("en-US")),
                    NormalizedEmail = Settings.Default.AdminEmail.ToUpper(new System.Globalization.CultureInfo("en-US")),
                    PasswordHash = hasher.HashPassword(null, Settings.Default.RolesAdminPassword),
                    LockoutEnabled = true,
                    EmailConfirmed = true,
                    Language = "tr-TR",
                    Timezone = TimeZoneInfo.Local.Id
                }
                );

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>
                {
                    UserId = Settings.Default.RolesAdminUserId,
                    RoleId = Settings.Default.RolesAdminRoleId
                }
                );

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>
                {
                    UserId = Settings.Default.RolesAdminUserId,
                    RoleId = Settings.Default.RolesSuperuserRoleId
                }
                );
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>
                {
                    UserId = Settings.Default.RolesAdminUserId,
                    RoleId = Settings.Default.RolesUserRoleId
                }
                );
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>
                {
                    UserId = Settings.Default.RolesAdminUserId,
                    RoleId = Settings.Default.RolesViewerRoleId
                }
                );
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>
                {
                    UserId = Settings.Default.RolesAdminUserId,
                    RoleId = Settings.Default.RolesGuestRoleId
                }
                );
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>
                {
                    UserId = Settings.Default.RolesAdminUserId,
                    RoleId = Settings.Default.RolesProducerRoleId
                }
                );
        }
    }
}
