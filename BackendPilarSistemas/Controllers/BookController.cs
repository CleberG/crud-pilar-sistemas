using Application.Dto.Book;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendPilarSistemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] BookRequestDTO userRequest)
        {
            await _bookService.Create(userRequest);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] BookRequestDTO userRequest)
        {
            await _bookService.Update(id, userRequest);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _bookService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<BookResponseDTO> GetById([FromRoute] Guid id)
        {
            return await _bookService.GetById(id);
        }

        [HttpGet]
        public async Task<IList<BookResponseDTO>> GetAll()
        {
            return await _bookService.GetAll();
        }
    }
}
