using MS.Blog.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MS.Blog.Domain.Abstract.Repositories;

namespace MS.Blog.Web.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly MSBlogDbContext dbContext;

		public UserRepository(MSBlogDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<IdentityUser>> GetAll()
		{
			var users = await dbContext.Users.ToListAsync();
			// Remove superAdmin from users list
			var superAdminUser = await dbContext.Users
				.FirstOrDefaultAsync(x => x.Email == "superadmin@msBlog.com");
			if (superAdminUser is not null)
			{
				users.Remove(superAdminUser);
			}
			return users;
		}
	}
}
