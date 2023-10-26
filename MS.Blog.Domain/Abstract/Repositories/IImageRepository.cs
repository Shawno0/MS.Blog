using Microsoft.AspNetCore.Http;

namespace MS.Blog.Domain.Abstract.Repositories
{
	public interface IImageRepository
	{
		Task<string> UploadAsync(IFormFile file);
	}
}
