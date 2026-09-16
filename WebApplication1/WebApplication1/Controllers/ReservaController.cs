using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaService _service;

        public ReservaController(ReservaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var reservas = await _service.ListarAsync();

            return Ok(reservas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var reserva = await _service.BuscarPorIdAsync(id);

            if (reserva == null)
                return NotFound();

            return Ok(reserva);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ReservaDto dto)
        {
            var reserva = await _service.CriarAsync(dto);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = reserva.Id },
                reserva
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(
            int id,
            ReservaDto dto)
        {
            var atualizado = await _service.AtualizarAsync(id, dto);

            if (!atualizado)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var excluido = await _service.ExcluirAsync(id);

            if (!excluido)
                return NotFound();

            return NoContent();
        }
    }
}