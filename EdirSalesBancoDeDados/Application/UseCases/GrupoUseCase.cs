using AutoMapper;
using EdirSalesBancoDeDados.Application.DTOs;
using EdirSalesBancoDeDados.Application.DTOs.ViewDetails;
using EdirSalesBancoDeDados.Application.Exceptions.GrupoExeption;
using EdirSalesBancoDeDados.Application.Interfaces;
using EdirSalesBancoDeDados.Domain;
using EdirSalesBancoDeDados.Domain.Interfaces;

namespace EdirSalesBancoDeDados.Application.UseCases
{
    public class GrupoUseCase : IGrupoUseCase
    {
        private readonly IGrupoRepository _grupoRepository;
        private readonly IMapper _mapper;
        public GrupoUseCase(IGrupoRepository grupoRepository, IMapper mapper)
        {
            _grupoRepository = grupoRepository;
            _mapper = mapper;
        }
        public async Task<GrupoDTO> AddGrupo(GrupoDTO grupoDto)
        {
            if (grupoDto != null)
            {
                var grupo = _mapper.Map<Grupo>(grupoDto);
                await _grupoRepository.Add(grupo);
                return grupoDto;
            }
            throw new NotImplementedException();
        }


        public async Task<GrupoDTO> AtualizarGrupo(int id, GrupoDTO grupoDto)
        {
            if (id == 0)
                throw new NotImplementedException();


            if (grupoDto == null)
                throw new NotImplementedException();

            var grupo = await _grupoRepository.GetById(id);
            if (grupo == null)
                throw new ExceptionGrupo(TiposDeErrosGrupoEnum.IdNotFound);
            var grupoMap = _mapper.Map<Grupo>(grupoDto);
            await _grupoRepository.Update(grupoMap);
            return grupoDto;
        }

        public async Task<GrupoDTO> BuscarPorId(int id)
        {
            var grupo = await _grupoRepository.GetById(id);

            if (grupo == null)
                throw new ExceptionGrupo(TiposDeErrosGrupoEnum.IdNotFound);

            return _mapper.Map<GrupoDTO>(grupo);
        }

        public async Task DeletarGrupo(int id)
        {
            if (id == 0)
                throw new NotImplementedException();

            var grupo = await _grupoRepository.GetById(id);

            if (grupo == null)
                throw new KeyNotFoundException("Id não encontrado");

            await _grupoRepository.Delete(grupo);
        }

        public async Task<DetalheGrupoDTO> DetalhesDoGrupo(int id)
        {
            if (id == 0) throw new NotImplementedException();

            var result = await _grupoRepository.DetalhesDoGrupo(id);
            if (result == null)
                throw new ExceptionGrupo(TiposDeErrosGrupoEnum.IdNotFound);

            var details = new DetalheGrupoDTO
            {
                IdGrupo = id,
                NomeGrupo = result.NomeGrupo,
                Municipes = result.Municipes.Select(
                    m => new DetalheMunicipeGrupo
                    {
                        IdMunicipe = m.Id,
                        NomeMunicipe = m.Nome
                    }).ToList()
            };


            return details;
        }

        public async Task<IEnumerable<GrupoDTO>> ListarTodos(int pagina, int tamanhoPagina)
        {
            var grupos = await _grupoRepository.List(pagina, tamanhoPagina);
            if (grupos != null)
            {
                return _mapper.Map<IEnumerable<GrupoDTO>>(grupos);
            }
            throw new NotImplementedException();
        }
    }
}
