using MS.Blog.Infrastructure.Data;
using MS.Blog.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using MS.Blog.Domain.Abstract.Repositories;

namespace MS.Blog.Infrastructure.Repositories
{
	public class BlogPostCommentRepository : IBlogPostCommentRepository
	{
		private readonly MSBlogDbContext msBlogDbContext;

		public BlogPostCommentRepository(MSBlogDbContext msBlogDbContext)
		{
			this.msBlogDbContext = msBlogDbContext;
		}
		public async Task<Comment> AddAsync(Comment blogPostComment)
		{
			await msBlogDbContext.BlogPostComment.AddAsync(blogPostComment);
			await msBlogDbContext.SaveChangesAsync();
			return blogPostComment;
		}

		public async Task<IEnumerable<Comment>> GetCommentsByBlogIdAsync(Guid blogPostId)
		{
			return await msBlogDbContext.BlogPostComment.Where(x => x.PostId == blogPostId)
				.ToListAsync();
		}
	}
}
