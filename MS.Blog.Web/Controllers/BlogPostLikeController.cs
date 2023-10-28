using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS.Blog.Domain.Abstract.Repositories;
using MS.Blog.Domain.Models.Entity;
using MS.Blog.Domain.ViewModels;

namespace MS.Blog.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogPostLikeController : ControllerBase
	{
		private readonly IBlogPostLikeRepository blogPostLikeRepository;

		public BlogPostLikeController(IBlogPostLikeRepository blogPostLikeRepository)
		{
			this.blogPostLikeRepository = blogPostLikeRepository;
		}

		[HttpPost]
		[Route("Add")]
		public async Task<IActionResult> AddLike([FromBody] AddLikeRequest addLikeRequest)
		{
			var model = new Like
			{
				PostId = addLikeRequest.BlogPostId,
				UserId = addLikeRequest.UserId
			};
			await blogPostLikeRepository.AddLikeForBlog(model);

			return Ok();
		}

		[HttpGet]
		[Route("{blogPostId:Guid}/totalLikes")]
		public async Task<IActionResult> GetTotalLikesForBlog([FromRoute] Guid blogPostId)
		{
			var totalLikes = await blogPostLikeRepository.GetTotalLikes(blogPostId);
			return Ok(totalLikes);
		}
	}
}
