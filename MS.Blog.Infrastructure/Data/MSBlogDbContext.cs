using MS.Blog.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace MS.Blog.Infrastructure.Data
{
    public class MSBlogDbContext : AuthDbContext
    {
        public MSBlogDbContext(DbContextOptions<MSBlogDbContext> options) : base(options)
        {
        }

        public DbSet<Post> BlogPosts { get; set; }

        public DbSet<Tag> Tags { get; set; }

		public DbSet<Like> BlogPostLike { get; set; }

		public DbSet<Comment> BlogPostComment { get; set; }

	}
}
