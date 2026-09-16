using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public class EmprestimoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmprestimoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Emprestimo>> ListarAsync()
        {
            return await _context.Emprestimos
                .Include(e => e.Usuario)
                .Include(e => e.Livro)
                .ToListAsync();
        }

        public async Task<Emprestimo?> BuscarPorIdAsync(int id)
        {
            return await _context.Emprestimos
                .Include(e => e.Usuario)
                .Include(e => e.Livro)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Emprestimo> CriarAsync(EmprestimoDto dto)
        {
            var emprestimo = _mapper.Map<Emprestimo>(dto);

            _context.Emprestimos.Add(emprestimo);
            await _context.SaveChangesAsync();

            return emprestimo;
        }

        public async Task<bool> AtualizarAsync(int id, EmprestimoDto dto)
        {
            var emprestimo = await _context.Emprestimos.FindAsync(id);

            if (emprestimo == null)
                return false;

            _mapper.Map(dto, emprestimo);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var emprestimo = await _context.Emprestimos.FindAsync(id);

            if (emprestimo == null)
                return false;

            _context.Emprestimos.Remove(emprestimo);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}