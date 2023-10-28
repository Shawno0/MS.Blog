using MS.Blog.Domain.Models.Entity;

namespace MS.Blog.Domain.ViewModels
{
	public class HomeViewModel
	{
        public IEnumerable<Post> BlogPosts { get; set; }
		
		public IEnumerable<Tag> Tags { get; set; }

	}
}
