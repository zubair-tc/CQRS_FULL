using MediatR;

namespace CleanArchitectureCQRSPatteren.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQuery:IRequest<List<BlogVm>>
    {
    }
}
