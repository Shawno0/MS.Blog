using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MS.Blog.Infrastructure.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            var adminRoleId = "32ca9872-382a-4bd6-a6e6-ca39739e3e1b";
            var superAdminRoleId = "92507cae-b1c3-4e8d-b8d9-d931ab192237";
            var userRoleId = "3b19458e-6b95-4358-8c65-d9573a27fe9b";

            var roles = new List<IdentityRole> {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                   Name = "SuperAdmin",
                   NormalizedName = "SuperAdmin",
                   Id = superAdminRoleId,
                   ConcurrencyStamp = superAdminRoleId
                },
                new IdentityRole
                {
                   Name = "User",
                   NormalizedName = "User",
                   Id = userRoleId,
                   ConcurrencyStamp = userRoleId
                }
            };

            builder.HasData(roles);

            builder.ToTable("Roles");
        }
    }
}
