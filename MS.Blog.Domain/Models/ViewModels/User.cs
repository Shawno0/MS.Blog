﻿namespace MS.Blog.Domain.ViewModels
{
	public class User
	{
		public Guid Id { get; set; }

		public string Username { get; set; }

		public string EmailAddress { get; set; }
		public bool EmailConfirmed { get; set; }
	}
}
