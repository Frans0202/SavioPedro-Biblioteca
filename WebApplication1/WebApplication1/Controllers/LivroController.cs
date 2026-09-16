using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly LivroService _service;

        public LivroController(LivroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var livros = await _service.ListarAsync();

            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var livro = await _service.BuscarPorIdAsync(id);

            if (livro == null)
                return NotFound();

            return Ok(livro);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(LivroDto dto)
        {
            var livro = await _service.CriarAsync(dto);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = livro.Id },
                livro
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, LivroDto dto)
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