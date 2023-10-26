using MS.Blog.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace MS.Blog.Infrastructure.Data
{
    public class MSBlogDbContext : DbContext
    {
        public MSBlogDbContext(DbContextOptions<MSBlogDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Tag> Tags { get; set; }

		public DbSet<BlogPostLike> BlogPostLike { get; set; }

		public DbSet<BlogPostComment> BlogPostComment { get; set; }

	}
}
