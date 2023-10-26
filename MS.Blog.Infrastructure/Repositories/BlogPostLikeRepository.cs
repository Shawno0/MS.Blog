using Microsoft.EntityFrameworkCore;
using MS.Blog.Domain.Models.Entity;
using MS.Blog.Infrastructure.Data;
using MS.Blog.Domain.Abstract.Repositories;

namespace MS.Blog.Infrastructure.Repositories
{
	public class BlogPostLikeRepository : IBlogPostLikeRepository
	{
		private readonly MSBlogDbContext msBlogDbContext;

		public BlogPostLikeRepository(MSBlogDbContext msBlogDbContext)
        {
			this.msBlogDbContext = msBlogDbContext;
		}

		public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
		{
			await msBlogDbContext.BlogPostLike.AddAsync(blogPostLike);
			await msBlogDbContext.SaveChangesAsync();
			return blogPostLike;
		}

		public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
		{
			return await msBlogDbContext.BlogPostLike.Where(x => x.BlogPostId == blogPostId)
				.ToListAsync();
		}

		public async Task<int> GetTotalLikes(Guid blogPostId)
		{
			return await msBlogDbContext.BlogPostLike
				.CountAsync(x => x.BlogPostId == blogPostId);
		}
	}
}
