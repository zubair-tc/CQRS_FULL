using CleanArchitectureCQRSPatteren.Application.Common.Mappings;
using CleanArchitectureCQRSPatteren.Domain.Entities;


namespace CleanArchitectureCQRSPatteren.Application.Blogs.Queries.GetBlogs
{
    public class BlogVm:IMapFrom<Blog>
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }

    }
}
