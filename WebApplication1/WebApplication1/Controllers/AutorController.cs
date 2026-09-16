using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly AutorService _service;

        public AutorController(AutorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var autores = await _service.ListarAsync();

            return Ok(autores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var autor = await _service.BuscarPorIdAsync(id);

            if (autor == null)
                return NotFound();

            return Ok(autor);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(AutorDto dto)
        {
            var autor = await _service.CriarAsync(dto);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = autor.Id },
                autor
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, AutorDto dto)
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