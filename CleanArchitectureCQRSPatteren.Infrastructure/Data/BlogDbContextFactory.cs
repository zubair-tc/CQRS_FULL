using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;


namespace CleanArchitectureCQRSPatteren.Infrastructure.Data
{
    public class BlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {
        public BlogDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();

            optionsBuilder.UseSqlServer("Server=ZUBAIR-BHATTI\\SQLEXPRESS;Database=BlogDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new BlogDbContext(optionsBuilder.Options);
        }
    }
}
