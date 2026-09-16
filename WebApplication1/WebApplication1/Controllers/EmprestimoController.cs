using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimoController : ControllerBase
    {
        private readonly EmprestimoService _service;

        public EmprestimoController(EmprestimoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var emprestimos = await _service.ListarAsync();

            return Ok(emprestimos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var emprestimo = await _service.BuscarPorIdAsync(id);

            if (emprestimo == null)
                return NotFound();

            return Ok(emprestimo);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(EmprestimoDto dto)
        {
            var emprestimo = await _service.CriarAsync(dto);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = emprestimo.Id },
                emprestimo
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(
            int id,
            EmprestimoDto dto)
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