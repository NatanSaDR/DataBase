using AutoMapper;
using EdirSalesBancoDeDados.Application.DTOs;
using EdirSalesBancoDeDados.Application.Interfaces;
using EdirSalesBancoDeDados.Domain;
using EdirSalesBancoDeDados.Domain.Interfaces;
using EdirSalesBancoDeDados.Infrastructure.Repositories;

namespace EdirSalesBancoDeDados.Application.UseCases
{
    public class SolicitacaoUseCase : ISolicitacaoUseCase
    {
        private readonly ISolicitacaoRepository _solicitacaoRepository;
        private readonly IGrupoRepository _grupoRepository;
        private readonly IMunicipeRepository _municipeRepository;
        private readonly IMapper _mapper;
        public SolicitacaoUseCase(ISolicitacaoRepository solicitacaoRepository, IMapper mapper, IMunicipeRepository municipeRepository,
            IGrupoRepository grupoRepository)
        {
            _solicitacaoRepository = solicitacaoRepository;
            _mapper = mapper;
            _solicitacaoRepository = solicitacaoRepository;
            _grupoRepository = grupoRepository;
        }
        public async Task<SolicitacaoDTO> AddSolicitacao(SolicitacaoDTO solicitacaoDto)
        {
            if (solicitacaoDto == null)
                throw new Exception();
            var solicitacao = _mapper.Map<Solicitacao>(solicitacaoDto);
            foreach (var dto in solicitacaoDto.IdMunicipes)
            {
                await 
            }
            await _solicitacaoRepository.Add(solicitacao);
            return solicitacaoDto;
        }

        public async Task<SolicitacaoDTO> AtualizarSolicitacao(int id, SolicitacaoDTO solicitacaoDto)
        {
            if (id == 0 || solicitacaoDto == null)
                throw new NotImplementedException();

            var result = await _solicitacaoRepository.GetById(id);
            if (result == null)
                throw new Exception();

            var solicitacao = _mapper.Map<Solicitacao>(solicitacaoDto);
            if (solicitacao == null) throw new Exception();

            await _solicitacaoRepository.Update(solicitacao);

            return solicitacaoDto;
        }


        public async Task<SolicitacaoDTO> BuscarPorId(int id)
        {
            if (id == 0) throw new NotImplementedException();

            var result = await _solicitacaoRepository.GetById(id);
            if (result == null) throw new Exception();

            var resultDto = _mapper.Map<SolicitacaoDTO>(result);
            if (resultDto == null) throw new Exception();

            return resultDto;
        }

        public async Task DeletarSolicitacao(int id)
        {
            if (id == 0) throw new NotImplementedException();

            var result = await _solicitacaoRepository.GetById(id);
            if (result == null) throw new Exception();

            await _solicitacaoRepository.Delete(result);
        }

        public async Task<ICollection<SolicitacaoDTO>> ListarTodos(int pagina, int tamanhoPagina)
        {
            if(pagina == 0) pagina = 1;
            var result = await _solicitacaoRepository.List(pagina, tamanhoPagina);

            var resultMap = _mapper.Map<ICollection<SolicitacaoDTO>>(result);

            foreach (var dto in resultMap)
            {
                var originalSolicitacao = result.First(r => r.Id == dto.Id);
                dto.IdGrupos = originalSolicitacao.Grupos.Select(g => g.Id).ToList();
                dto.IdMunicipes = originalSolicitacao.Municipes.Select(m => m.Id).ToList();
            }
            return resultMap;
                
        }
    }
}
