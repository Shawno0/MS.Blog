namespace MS.Blog.Domain.Models.Entity
{
	public class Comment
	{
        public Guid Id { get; set; }
		public string? Description { get; set; }
		public Guid? PostId { get; set; }
		public virtual Post? Post { get; set; }
		public Guid? UserId { get; set; }
		public DateTime DateAdded { get; set; }
	}
}
