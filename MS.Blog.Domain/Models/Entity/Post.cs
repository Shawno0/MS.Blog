﻿namespace MS.Blog.Domain.Models.Entity
{
    public class Post
    {
        public Guid Id { get; set; }
        public string? Heading { get; set; }
        public string? PageTitle { get; set; }
        public string? Content { get; set; }
        public string? ShortDescription { get; set; }
        public string? FeaturedImageUrl { get; set; }
        public string? UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string? Author { get; set; }
        public bool Visible { get; set; }

        //Navigation property
        public ICollection<Tag>? Tags { get; set; }

        public ICollection<Like>? Likes { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}
