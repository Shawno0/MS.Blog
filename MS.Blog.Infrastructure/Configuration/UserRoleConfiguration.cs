using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MS.Blog.Infrastructure.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            var superAdminId = "79bd71db-0b95-4e05-a894-f5f538ec8c9f";

            var adminRoleId = "32ca9872-382a-4bd6-a6e6-ca39739e3e1b";
            var superAdminRoleId = "92507cae-b1c3-4e8d-b8d9-d931ab192237";
            var userRoleId = "3b19458e-6b95-4358-8c65-d9573a27fe9b";

            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId,
                },
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId,
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId,
                }
            };

            builder.HasData(superAdminRoles);

            builder.ToTable("UserRoles");
        }
    }
}
