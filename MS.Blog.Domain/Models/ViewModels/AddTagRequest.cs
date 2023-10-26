using System.ComponentModel.DataAnnotations;

namespace MS.Blog.Domain.ViewModels
{
	public class AddTagRequest
	{
		[Required]
        public string Name { get; set; }

		[Required]
		public string DisplayName { get; set; }
	}
}
