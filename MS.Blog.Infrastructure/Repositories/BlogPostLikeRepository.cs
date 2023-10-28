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

		public async Task<Like> AddLikeForBlog(Like blogPostLike)
		{
			await msBlogDbContext.BlogPostLike.AddAsync(blogPostLike);
			await msBlogDbContext.SaveChangesAsync();
			return blogPostLike;
		}

		public async Task<IEnumerable<Like>> GetLikesForBlog(Guid blogPostId)
		{
			return await msBlogDbContext.BlogPostLike.Where(x => x.PostId == blogPostId)
				.ToListAsync();
		}

		public async Task<int> GetTotalLikes(Guid blogPostId)
		{
			return await msBlogDbContext.BlogPostLike
				.CountAsync(x => x.PostId == blogPostId);
		}
	}
}
