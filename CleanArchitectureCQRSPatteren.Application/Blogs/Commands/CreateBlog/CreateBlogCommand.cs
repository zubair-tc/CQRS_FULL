using CleanArchitectureCQRSPatteren.Application.Blogs.Queries.GetBlogs;


namespace CleanArchitectureCQRSPatteren.Application.Blogs.Commands.CreateBlog
{
    public  class CreateBlogCommand:IRequest<BlogVm>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public string ImageUrl { get;set; }
    }
}
