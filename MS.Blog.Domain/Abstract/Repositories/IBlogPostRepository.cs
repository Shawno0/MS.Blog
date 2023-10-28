using MS.Blog.Domain.Models.Entity;

namespace MS.Blog.Domain.Abstract.Repositories
{
	public interface IBlogPostRepository
	{
		Task<IEnumerable<Post>> GetAllAsync();

		Task<Post?> GetAsync(Guid id);

		Task<Post?> GetByUrlHandleAsync(string urlHandle);

		Task<Post> AddAsync(Post blogPost);

		Task<Post?> UpdateAsync(Post blogPost);

		Task<Post?> DeleteAsync(Guid id);

	}
}
