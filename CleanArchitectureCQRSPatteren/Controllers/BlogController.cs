using CleanArchitectureCQRSPatteren.Application.Blogs.Commands.CreateBlog;
using CleanArchitectureCQRSPatteren.Application.Blogs.Commands.DeleteBlog;
using CleanArchitectureCQRSPatteren.Application.Blogs.Commands.UpdateBlog;
using CleanArchitectureCQRSPatteren.Application.Blogs.Queries.GetBlogById;
using CleanArchitectureCQRSPatteren.Application.Blogs.Queries.GetBlogs;
using Microsoft.AspNetCore.Mvc;


namespace CleanArchitectureCQRSPatteren.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blog = await Mediator.Send(new GetBlogQuery());
            return Ok(blog);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery() { BlogId = id });
            if (blog == null)
                return NotFound();
            return Ok(blog);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand blog)
        {
            var createdBlog = await Mediator.Send(blog);
            return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdateBlogCommand command)
        {
            if(id!=command.Id)
                return BadRequest();

            await Mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result=await Mediator.Send(new DeleteBlogCommand { Id = id });

            if (result == 0)
                return BadRequest();

            return NoContent();
            
        }
    }
}
