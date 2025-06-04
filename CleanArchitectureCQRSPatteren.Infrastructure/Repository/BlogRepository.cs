using CleanArchitectureCQRSPatteren.Domain.Entities;
using CleanArchitectureCQRSPatteren.Domain.Repository;
using CleanArchitectureCQRSPatteren.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureCQRSPatteren.Infrastructure.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _blogDbContext;

        public BlogRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
            await  _blogDbContext.Blogs.AddAsync(blog);
            await _blogDbContext.SaveChangesAsync();
            return blog;
        }
        public async Task<int> DeleteAsync(int id)
        {
            return await _blogDbContext.Blogs.Where(model => model.Id == id).ExecuteDeleteAsync();
        }
        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await _blogDbContext.Blogs.ToListAsync();
        }
        public async  Task<Blog> GetByIdAsync(int id)
        {

            return await _blogDbContext.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async  Task<int> UpdateAsync(int id, Blog blog)
        {
            return await _blogDbContext.Blogs.Where(x => x.Id == id).ExecuteUpdateAsync(setters => setters.SetProperty(m => m.Name, blog.Name).SetProperty(m => m.Author, blog.Author).SetProperty(m => m.Description, blog.Description).SetProperty(m => m.ImageUrl, blog.ImageUrl));
        }
    }
}
