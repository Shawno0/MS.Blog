using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MS.Blog.Domain.ViewModels
{
	public class AddBlogPostRequest
	{
		[Required]
		[MinLength(5)]
		public string? Heading { get; set; }
        [Required]
        [MinLength(5)]
        public string? PageTitle { get; set; }
        [Required]
        [MinLength(5)]
        public string? Content { get; set; }
        [Required]
        [MinLength(5)]
        public string? ShortDescription { get; set; }
		public string? FeaturedImageUrl { get; set; }
		public string? UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        [Required]
        [MinLength(5)]
        public string? Author { get; set; }
		public bool Visible { get; set; }

        // Display tags
        public IEnumerable<SelectListItem>? Tags { get; set; }
		// Collect tag
		public string[] SelectedTags { get; set; } = Array.Empty<string>();
    }
}
