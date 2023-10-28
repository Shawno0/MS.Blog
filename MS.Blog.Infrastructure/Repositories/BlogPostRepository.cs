using Microsoft.EntityFrameworkCore;
using MS.Blog.Domain.Models.Entity;
using MS.Blog.Domain.Abstract.Repositories;
using MS.Blog.Infrastructure.Data;

namespace MS.Blog.Infrastructure.Repositories
{
	public class BlogPostRepository : IBlogPostRepository
	{
		private readonly MSBlogDbContext msBlogDbContext;

		public BlogPostRepository(MSBlogDbContext msBlogDbContext)
		{
			this.msBlogDbContext = msBlogDbContext;
		}

		public async Task<Post> AddAsync(Post blogPost)
		{
			await msBlogDbContext.AddAsync(blogPost);
			await msBlogDbContext.SaveChangesAsync();
			return blogPost;
		}

		public async Task<Post?> DeleteAsync(Guid id)
		{
			var existingBlog = await msBlogDbContext.BlogPosts.FindAsync(id);
			if (existingBlog != null)
			{
				msBlogDbContext.BlogPosts.Remove(existingBlog);
				await msBlogDbContext.SaveChangesAsync();
				return existingBlog;
			}
			return null;
		}

		public async Task<IEnumerable<Post>> GetAllAsync()
		{
			return await msBlogDbContext.BlogPosts.Include(x => x.Tags).ToListAsync();
		}

		public async Task<Post?> GetAsync(Guid id)
		{
			return await msBlogDbContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Post?> GetByUrlHandleAsync(string urlHandle)
		{
			return await msBlogDbContext.BlogPosts.Include(x => x.Tags)
				.FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
		}

		public async Task<Post?> UpdateAsync(Post blogPost)
		{
			var existingBlog = await msBlogDbContext.BlogPosts.Include(x => x.Tags)
				.FirstOrDefaultAsync(x => x.Id == blogPost.Id);

			if (existingBlog != null)
			{
				existingBlog.Id = blogPost.Id;
				existingBlog.Heading = blogPost.Heading;
				existingBlog.PageTitle = blogPost.PageTitle;
				existingBlog.Content = blogPost.Content;
				existingBlog.ShortDescription = blogPost.ShortDescription;
				existingBlog.Author = blogPost.Author;
				existingBlog.FeaturedImageUrl = blogPost.FeaturedImageUrl;
				existingBlog.UrlHandle = blogPost.UrlHandle;
				existingBlog.Visible = blogPost.Visible;
				existingBlog.PublishedDate = blogPost.PublishedDate;
				existingBlog.Tags = blogPost.Tags;

				await msBlogDbContext.SaveChangesAsync();
				return existingBlog;
			}
			return null;
		}
	}
}
