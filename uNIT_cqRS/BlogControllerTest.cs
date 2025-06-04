using CleanArchitectureCQRSPatteren.Application.Blogs.Commands.CreateBlog;
using CleanArchitectureCQRSPatteren.Application.Blogs.Commands.DeleteBlog;
using CleanArchitectureCQRSPatteren.Application.Blogs.Commands.UpdateBlog;
using CleanArchitectureCQRSPatteren.Application.Blogs.Queries.GetBlogById;
using CleanArchitectureCQRSPatteren.Application.Blogs.Queries.GetBlogs;
using CleanArchitectureCQRSPatteren.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CleanArchitectureCQRSPatteren.Tests.Controllers
{
    public class BlogControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly BlogController _sut;

        public BlogControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _sut = new BlogController();
            _sut.SetMediator(_mediatorMock.Object);  // Use the new setter
           
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfBlogs()
        {
            // Arrange
            var blogs = new List<BlogVm> { new BlogVm { Id = 1} };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBlogQuery>(), default))
                         .ReturnsAsync(blogs);

            // Act
            var result = await _sut.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualBlogs = Assert.IsAssignableFrom<List<BlogVm>>(okResult.Value);
            Assert.Equal(actualBlogs[0].Id, blogs[0].Id);
        }

        [Fact]
        public async Task GetById_ReturnsOkResult_WhenBlogExists()
        {
            // Arrange
            var blog = new BlogVm { Id = 1, Name = "Blog1" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBlogByIdQuery>(), default))
                         .ReturnsAsync(blog);

            // Act
            var result = await _sut.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(blog, okResult.Value);


        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenBlogIsNull()
        {
            //Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBlogByIdQuery>(), default))
                         .ReturnsAsync((BlogVm)null);
            //ACt
            var result = await _sut.GetById(2);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsCreatedAtAction()
        {
            // Arrange
            var createCommand = new CreateBlogCommand { Name = "New Blog" };
            var createdDto = new BlogVm { Id = 1, Name = "New Blog" };

            _mediatorMock.Setup(m => m.Send(createCommand, default))
                         .ReturnsAsync(createdDto);
            // Act
            var result = await _sut.Create(createCommand);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnedDto= Assert.IsType<BlogVm>(createdAtActionResult.Value);
            Assert.Equal(createdDto.Name, returnedDto.Name);
        }

        [Fact]
        public async Task Update_ReturnsNoContent_WhenValid()
        {
            //Assert
            var command = new UpdateBlogCommand { Id = 1, Name = "Updated" };

            _mediatorMock.Setup(m => m.Send(command, default)).ReturnsAsync(1);

            //Act
            var result = await _sut.Update(1, command);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Update_ReturnsBadRequest_WhenIdMismatch()
        {
            //Arrange
            var command = new UpdateBlogCommand { Id = 2, Name = "Updated" };

            //Act
            var result = await _sut.Update(1, command);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNoContent_WhenDeleted()
        {
            //Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteBlogCommand>(), default))
                         .ReturnsAsync(1);
            //Act
            var result = await _sut.Delete(1);
            var result2 = await _sut.Delete(1);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsBadRequest_WhenNotDeleted()
        {
            //Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteBlogCommand>(), default))
                         .ReturnsAsync(0);
            //ACt
            var result = await _sut.Delete(999);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}