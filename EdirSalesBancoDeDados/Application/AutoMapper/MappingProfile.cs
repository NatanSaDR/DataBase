using AutoMapper;
using EdirSalesBancoDeDados.Application.DTOs;
using EdirSalesBancoDeDados.Application.DTOs.ViewDetailsMunicipe;
using EdirSalesBancoDeDados.Domain;

namespace SimpleCRUD.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Grupo, GrupoDTO>().ReverseMap();
            CreateMap<Municipe, MunicipeDTO>().ReverseMap();
            CreateMap<Municipe, DetalheMunicipe>().ReverseMap();
            CreateMap<Solicitacao, SolicitacaoDTO>().ReverseMap();
        }
    }
}
