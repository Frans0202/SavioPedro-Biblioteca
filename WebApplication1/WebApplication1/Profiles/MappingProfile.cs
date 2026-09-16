using AutoMapper;
using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<AutorDto, Autor>();
            CreateMap<LivroDto, Livro>();
            CreateMap<EmprestimoDto, Emprestimo>();
            CreateMap<ReservaDto, Reserva>();
            CreateMap<PenalidadeDto, Penalidade>();
        }
    }
}