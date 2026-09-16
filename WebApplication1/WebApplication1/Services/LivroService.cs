using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public class LivroService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LivroService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Livro>> ListarAsync()
        {
            return await _context.Livros
                .Include(l => l.Autores)
                .ToListAsync();
        }

        public async Task<Livro?> BuscarPorIdAsync(int id)
        {
            return await _context.Livros
                .Include(l => l.Autores)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Livro> CriarAsync(LivroDto dto)
        {
            var livro = _mapper.Map<Livro>(dto);

            if (dto.AutoresIds.Any())
            {
                livro.Autores = await _context.Autores
                    .Where(a => dto.AutoresIds.Contains(a.Id))
                    .ToListAsync();
            }

            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            return livro;
        }

        public async Task<bool> AtualizarAsync(int id, LivroDto dto)
        {
            var livro = await _context.Livros
                .Include(l => l.Autores)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (livro == null)
                return false;

            _mapper.Map(dto, livro);

            livro.Autores = await _context.Autores
                .Where(a => dto.AutoresIds.Contains(a.Id))
                .ToListAsync();

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);

            if (livro == null)
                return false;

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}