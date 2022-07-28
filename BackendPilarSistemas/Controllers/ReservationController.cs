using Application.Dto.ReservationsDTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendPilarSistemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ReservationRequestDTO userRequest)
        {
            await _reservationService.Create(userRequest);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] ReservationRequestDTO userRequest)
        {
            await _reservationService.Update(id, userRequest);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _reservationService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ReservationResponseDTO> GetById([FromRoute] Guid id)
        {
            return await _reservationService.GetById(id);
        }

        [HttpGet]
        public async Task<IList<ReservationResponseDTO>> GetAll()
        {
            return await _reservationService.GetAll();
        }
    }
}
