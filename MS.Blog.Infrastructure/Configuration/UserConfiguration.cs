using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MS.Blog.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var superAdminId = "79bd71db-0b95-4e05-a894-f5f538ec8c9f";

            var superAdminUser = new IdentityUser
            {
                UserName = "James Stoner",
                Email = "james@milliestoner.com",
                NormalizedEmail = "james@milliestoner.com".ToUpper(),
                NormalizedUserName = "JAMES STONER".ToUpper(),
                Id = superAdminId
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "Letj4m35in$");

            builder.HasData(superAdminUser);

            builder.ToTable("Users");
        }
    }
}
