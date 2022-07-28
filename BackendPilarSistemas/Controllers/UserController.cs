using Application.Dto.UserDTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendPilarSistemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserRequestDTO userRequest)
        {
            await _userService.Create(userRequest);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] UserRequestDTO userRequest)
        {
            await _userService.Update(id, userRequest);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _userService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<UserResponseDTO> GetById([FromRoute] Guid id)
        {
            return await _userService.GetById(id);
        }

        [HttpGet]
        public async Task<IList<UserResponseDTO>> GetAll()
        {
            return await _userService.GetAll();
        }
    }
}
