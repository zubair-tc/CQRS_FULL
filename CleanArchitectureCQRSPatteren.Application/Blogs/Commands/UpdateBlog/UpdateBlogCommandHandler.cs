using CleanArchitectureCQRSPatteren.Application.Blogs.Commands.UpdateBlog;
using CleanArchitectureCQRSPatteren.Domain.Entities;
using CleanArchitectureCQRSPatteren.Domain.Repository;
using MediatR;

namespace CleanArchWithCQRSandMediator.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var UdateblogEntity = new Blog()
            {

                Author = request.Author,
                Description = request.Description,
                Name = request.Name,
                ImageUrl = request.ImageUrl,
            };

            return await _blogRepository.UpdateAsync(request.Id, UdateblogEntity);
        }
    }
}