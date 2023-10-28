using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MS.Blog.Infrastructure.Configuration;

namespace MS.Blog.Infrastructure.Data
{
	public class AuthDbContext : IdentityDbContext
	{
		public AuthDbContext(DbContextOptions<MSBlogDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Seed roles (User,Admin,SuperAdmin) 
			builder.ApplyConfiguration(new RoleConfiguration());

			//Seed SuperAdminUser
			builder.ApplyConfiguration(new UserConfiguration());

			//Add all the roles to SuperAdminUser
			builder.ApplyConfiguration(new UserRoleConfiguration());

			builder.ApplyConfiguration(new UserLoginConfiguration());

			builder.ApplyConfiguration(new UserClaimConfiguration());

			builder.ApplyConfiguration(new UserTokenConfiguration());

			builder.ApplyConfiguration(new RoleClaimConfiguration());
		}
	}
}
