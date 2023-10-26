using MS.Blog.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MS.Blog.Domain.Abstract.Repositories;

namespace MS.Blog.Web.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly AuthDbContext authDbContext;

		public UserRepository(AuthDbContext authDbContext)
		{
			this.authDbContext = authDbContext;
		}

		public async Task<IEnumerable<IdentityUser>> GetAll()
		{
			var users = await authDbContext.Users.ToListAsync();
			// Remove superAdmin from users list
			var superAdminUser = await authDbContext.Users
				.FirstOrDefaultAsync(x => x.Email == "superadmin@msBlog.com");
			if (superAdminUser is not null)
			{
				users.Remove(superAdminUser);
			}
			return users;
		}
	}
}
