using CleanArchitectureCQRSPatteren.Application.Blogs.Commands.CreateBlog;
using FluentValidation;

namespace CleanArchitectureCQRSPatteren.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandValidator : AbstractValidator<DeleteBlogCommand>
    {
        public DeleteBlogCommandValidator()
        {
            RuleFor(v => v.Id).NotNull()
              .WithMessage("Id is required.");
        }
    }
}
