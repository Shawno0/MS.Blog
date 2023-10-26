using Microsoft.AspNetCore.Identity;

namespace MS.Blog.Domain.Abstract.Repositories
{
	public interface IUserRepository
	{
		Task<IEnumerable<IdentityUser>> GetAll();
	}
}
