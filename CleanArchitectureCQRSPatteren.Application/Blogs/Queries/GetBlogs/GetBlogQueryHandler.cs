using AutoMapper;
using CleanArchitectureCQRSPatteren.Domain.Repository;
using MediatR;

namespace CleanArchitectureCQRSPatteren.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVm>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public GetBlogQueryHandler(IBlogRepository blogRepository,IMapper mapper)
        {
            _blogRepository=blogRepository;
            _mapper=mapper;
        }
        public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs=await _blogRepository.GetAllBlogsAsync();
           // var bloglist=blogs.Select(x => new GetBlogVm { Author = x.Author, Name = x.Name, Description = x.Description, Id = x.Id }).ToList();
           var bloglist=_mapper.Map<List<BlogVm>>(blogs);
            return bloglist;
        }
    }
}
