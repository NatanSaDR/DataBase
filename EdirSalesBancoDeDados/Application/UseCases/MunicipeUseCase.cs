using AutoMapper;
using EdirSalesBancoDeDados.Application.DTOs;
using EdirSalesBancoDeDados.Application.DTOs.ViewDetailsMunicipe;
using EdirSalesBancoDeDados.Application.Interfaces;
using EdirSalesBancoDeDados.Domain;
using EdirSalesBancoDeDados.Domain.Interfaces;

namespace EdirSalesBancoDeDados.Application.UseCases
{
    public class MunicipeUseCase : IMunicipeUseCase
    {
        private readonly IMunicipeRepository _municipeRepository;
        private readonly IGrupoRepository _grupoRepository;
        private readonly IMapper _mapper;

        public MunicipeUseCase(IMunicipeRepository municipeRepository, IMapper mapper, IGrupoRepository grupoRepository)
        {
            _municipeRepository = municipeRepository;
            _mapper = mapper;
            _grupoRepository = grupoRepository;
        }
        public async Task<MunicipeDTO> AddMunicipe(MunicipeDTO municipeDto)
        {
            if (municipeDto == null || municipeDto.GruposId == null)
                throw new ArgumentNullException();
            var municipe = _mapper.Map<Municipe>(municipeDto);
            foreach (var grupo in municipeDto.GruposId)
            {
                var grupoMunicipe = await _grupoRepository.GetById(grupo);
                if (grupoMunicipe != null)
                    municipe.Grupos.Add(grupoMunicipe);
            }
            await _municipeRepository.Add(municipe);
            return municipeDto;
        }

        public async Task<MunicipeDTO> AtualizarMunicipe(int id, MunicipeDTO municipeDto)
        {
            if (id == 0)
                throw new NotImplementedException();

            var municipe = await _municipeRepository.GetById(id);

            if (municipe == null)
                throw new NotImplementedException();
            var municipeMap = _mapper.Map<Municipe>(municipeDto);
            await _municipeRepository.Update(municipeMap);
            return municipeDto;
        }

        public async Task<MunicipeDTO> BuscarPorId(int id)
        {
            if (id == 0)
                throw new NotImplementedException();

            var municipe = await _municipeRepository.GetById(id);
            if (municipe == null)
                throw new NotImplementedException();

            return _mapper.Map<MunicipeDTO>(municipe);
        }

        public async Task DeletarMunicipe(int id)
        {
            if (id == 0)
                throw new NotImplementedException();

            var municipe = await _municipeRepository.GetById(id);

            if (municipe == null)
                throw new NotImplementedException();

            await _municipeRepository.Delete(municipe);
        }

        public async Task<ICollection<DetalheMunicipe>> ListarTodos(int pagina, int tamanhoPagina)
        {
            var municipes = await _municipeRepository.List(pagina, tamanhoPagina);

            if (municipes == null)
                throw new NotImplementedException();

            var municipesMap = _mapper.Map<ICollection<DetalheMunicipe>>(municipes);
            
            return municipesMap;
        }

        public async Task<MunicipeDTO> AdicionarGrupo(int idMunicipe, int idGrupo)
        {
            var municipe = await _municipeRepository.GetById(idMunicipe);
            if (municipe == null)
                throw new ArgumentException();

            var grupo = await _grupoRepository.GetById(idGrupo);
            if (grupo == null)
                throw new ArgumentException();

            municipe.Grupos.Add(grupo);

            await _municipeRepository.Update(municipe);
            var municipeDto = _mapper.Map<MunicipeDTO>(municipe);
            return municipeDto;
        }
    }
}
