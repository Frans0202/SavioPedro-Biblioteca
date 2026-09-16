using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public class PenalidadeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PenalidadeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Penalidade>> ListarAsync()
        {
            return await _context.Penalidades
                .Include(p => p.Usuario)
                .Include(p => p.Emprestimo)
                .ToListAsync();
        }

        public async Task<Penalidade?> BuscarPorIdAsync(int id)
        {
            return await _context.Penalidades
                .Include(p => p.Usuario)
                .Include(p => p.Emprestimo)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Penalidade> CriarAsync(PenalidadeDto dto)
        {
            var penalidade = _mapper.Map<Penalidade>(dto);

            _context.Penalidades.Add(penalidade);
            await _context.SaveChangesAsync();

            return penalidade;
        }

        public async Task<bool> AtualizarAsync(int id, PenalidadeDto dto)
        {
            var penalidade = await _context.Penalidades.FindAsync(id);

            if (penalidade == null)
                return false;

            _mapper.Map(dto, penalidade);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var penalidade = await _context.Penalidades.FindAsync(id);

            if (penalidade == null)
                return false;

            _context.Penalidades.Remove(penalidade);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}