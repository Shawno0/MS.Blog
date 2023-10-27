using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MS.Blog.Domain.Abstract.Repositories;
using MS.Blog.Infrastructure.Data;
using MS.Blog.Infrastructure.Repositories;
using MS.Blog.Web.Repositories;

namespace MS.Blog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            services.AddDbContext<MSBlogDbContext>(options =>
            options.UseMySQL(
                configuration.GetConnectionString("DefaultConnection"),
                options => options.MigrationsAssembly(typeof(MSBlogDbContext).Assembly.FullName)));

            services
                .AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MSBlogDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                //Default settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });

            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            services.AddScoped<IImageRepository, CloudinaryImageRepository>();
            services.AddScoped<IBlogPostLikeRepository, BlogPostLikeRepository>();
            services.AddScoped<IBlogPostCommentRepository, BlogPostCommentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
