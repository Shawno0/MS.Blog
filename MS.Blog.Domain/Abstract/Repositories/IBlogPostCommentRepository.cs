using MS.Blog.Domain.Models.Entity;

namespace MS.Blog.Domain.Abstract.Repositories
{
	public interface IBlogPostCommentRepository
	{
		Task<Comment> AddAsync(Comment blogPostComment);

		Task<IEnumerable<Comment>> GetCommentsByBlogIdAsync(Guid blogPostId);
	}
}
