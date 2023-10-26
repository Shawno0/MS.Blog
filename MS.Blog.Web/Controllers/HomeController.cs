﻿using Microsoft.AspNetCore.Mvc;
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
			//getting all blogs
			var blogPosts = await blogPostRepository.GetAllAsync();
			//get all tags
			var tags = await tagRepository.GetAllAsync();

			//combine 2 models in one. 
			var model = new HomeViewModel
			{
				BlogPosts = blogPosts,
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