using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PenalidadeController : ControllerBase
    {
        private readonly PenalidadeService _service;

        public PenalidadeController(PenalidadeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var penalidades = await _service.ListarAsync();

            return Ok(penalidades);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var penalidade = await _service.BuscarPorIdAsync(id);

            if (penalidade == null)
                return NotFound();

            return Ok(penalidade);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(PenalidadeDto dto)
        {
            var penalidade = await _service.CriarAsync(dto);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = penalidade.Id },
                penalidade
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(
            int id,
            PenalidadeDto dto)
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