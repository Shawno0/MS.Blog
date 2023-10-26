using MS.Blog.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using MS.Blog.Domain.Abstract.Repositories;
using MS.Blog.Infrastructure.Data;

namespace MS.Blog.Web.Repositories
{
	public class TagRepository : ITagRepository
	{
		private readonly MSBlogDbContext msBlogDbContext;

		public TagRepository(MSBlogDbContext msBlogDbContext)
		{
			this.msBlogDbContext = msBlogDbContext;
		}

		public async Task<Tag> AddAsync(Tag tag)
		{
			await msBlogDbContext.Tags.AddAsync(tag);
			await msBlogDbContext.SaveChangesAsync();
			return tag;
		}

		public async Task<Tag?> DeleteAsync(Guid id)
		{
			var existingTag = await msBlogDbContext.Tags.FindAsync(id);
			if (existingTag != null)
			{
				msBlogDbContext.Tags.Remove(existingTag);
				await msBlogDbContext.SaveChangesAsync();
				return existingTag;
			}
			return null;
		}

		public async Task<IEnumerable<Tag>> GetAllAsync()
		{
			return await msBlogDbContext.Tags.ToListAsync();
		}

		public Task<Tag?> GetAsync(Guid id)
		{
			return msBlogDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Tag?> UpdateAsync(Tag tag)
		{
			var existingTag = await msBlogDbContext.Tags.FindAsync(tag.Id);
			if (existingTag != null)
			{
				existingTag.Name = tag.Name;
				existingTag.DisplayName = tag.DisplayName;

				await msBlogDbContext.SaveChangesAsync();

				return existingTag;
			}

			return null;
		}
	}
}
