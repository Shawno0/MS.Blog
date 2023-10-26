using MS.Blog.Domain.Models.Entity;

namespace MS.Blog.Domain.Abstract.Repositories
{
	public interface IBlogPostLikeRepository
	{
		Task<int> GetTotalLikes(Guid blogPostId);

		Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId);

		Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike);

	}
}
