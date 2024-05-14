using Microsoft.AspNetCore.Mvc;
using MS.Blog.Domain.Abstract.Repositories;
using MS.Blog.Domain.Models;
using MS.Blog.Domain.ViewModels;
using System.Diagnostics;

namespace MS.Blog.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IBlogPostRepository blogPostRepository;
		private readonly ITagRepository tagRepository;

		public HomeController(ILogger<HomeController> logger,
			IBlogPostRepository blogPostRepository,
			ITagRepository tagRepository)
		{
			_logger = logger;
			this.blogPostRepository = blogPostRepository;
			this.tagRepository = tagRepository;
		}

		public async Task<IActionResult> Index()
		{
			var posts = await blogPostRepository.GetAllAsync();

			if (User.Identity == null || User?.Identity?.IsAuthenticated == false)
			{
				posts = posts.Where(p => p.Visible == true);
			}

			var tags = await tagRepository.GetAllAsync();

			var model = new HomeViewModel
			{
				BlogPosts = posts,
				Tags = tags
			};

			return View(model);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}