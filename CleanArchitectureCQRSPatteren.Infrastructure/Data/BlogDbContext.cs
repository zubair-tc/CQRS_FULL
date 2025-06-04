using CleanArchitectureCQRSPatteren.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRSPatteren.Infrastructure.Data
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions):base(dbContextOptions) 
        { 

        }
        public DbSet<Blog> Blogs { get; set; }
    }
}
