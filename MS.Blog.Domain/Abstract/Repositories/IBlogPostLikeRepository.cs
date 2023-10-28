using MS.Blog.Domain.Models.Entity;

namespace MS.Blog.Domain.Abstract.Repositories
{
	public interface IBlogPostLikeRepository
	{
		Task<int> GetTotalLikes(Guid blogPostId);

		Task<IEnumerable<Like>> GetLikesForBlog(Guid blogPostId);

		Task<Like> AddLikeForBlog(Like blogPostLike);

	}
}
