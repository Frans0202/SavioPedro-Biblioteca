using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public class ReservaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ReservaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Reserva>> ListarAsync()
        {
            return await _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Livro)
                .ToListAsync();
        }

        public async Task<Reserva?> BuscarPorIdAsync(int id)
        {
            return await _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Livro)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Reserva> CriarAsync(ReservaDto dto)
        {
            var reserva = _mapper.Map<Reserva>(dto);

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return reserva;
        }

        public async Task<bool> AtualizarAsync(int id, ReservaDto dto)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva == null)
                return false;

            _mapper.Map(dto, reserva);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva == null)
                return false;

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}