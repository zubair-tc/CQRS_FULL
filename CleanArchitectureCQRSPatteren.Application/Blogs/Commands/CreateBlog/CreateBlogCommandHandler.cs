using AutoMapper;
using CleanArchitectureCQRSPatteren.Application.Blogs.Queries.GetBlogs;
using CleanArchitectureCQRSPatteren.Domain.Entities;
using CleanArchitectureCQRSPatteren.Domain.Repository;
using MediatR;

namespace CleanArchitectureCQRSPatteren.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVm>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public CreateBlogCommandHandler(IBlogRepository blogRepository,IMapper mapper)
        {
            _blogRepository=blogRepository;
            _mapper=mapper;
        }
        public async Task<BlogVm> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blogentity = new Blog() { Name=request.Name,Author=request.Author,Description=request.Description,ImageUrl=request.ImageUrl};
            var result = await _blogRepository.CreateAsync(blogentity);
            return _mapper.Map<BlogVm>(result);
        }
    }
}
