using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public class AutorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AutorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Autor>> ListarAsync()
        {
            return await _context.Autores.ToListAsync();
        }

        public async Task<Autor?> BuscarPorIdAsync(int id)
        {
            return await _context.Autores.FindAsync(id);
        }

        public async Task<Autor> CriarAsync(AutorDto dto)
        {
            var autor = _mapper.Map<Autor>(dto);

            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();

            return autor;
        }

        public async Task<bool> AtualizarAsync(int id, AutorDto dto)
        {
            var autor = await _context.Autores.FindAsync(id);

            if (autor == null)
                return false;

            _mapper.Map(dto, autor);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var autor = await _context.Autores.FindAsync(id);

            if (autor == null)
                return false;

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}