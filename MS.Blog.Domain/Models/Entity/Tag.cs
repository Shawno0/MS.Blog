namespace MS.Blog.Domain.Models.Entity
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public ICollection<Post>? BlogPosts { get; set; }

    }
}
