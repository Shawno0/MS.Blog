namespace MS.Blog.Domain.Models.Entity
{
	public class Like
	{
        public Guid Id { get; set; }

		public Guid? PostId { get; set; }
		public virtual Post? Post { get; set; }

		public Guid? UserId { get; set; }
	}
}
