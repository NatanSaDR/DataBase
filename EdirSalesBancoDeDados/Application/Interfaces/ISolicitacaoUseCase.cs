using EdirSalesBancoDeDados.Application.DTOs;

namespace EdirSalesBancoDeDados.Application.Interfaces
{
    public interface ISolicitacaoUseCase
    {
        Task<SolicitacaoDTO> AddSolicitacao(SolicitacaoDTO solicitacaoDto);
        Task DeletarSolicitacao(int id);
        Task<SolicitacaoDTO> AtualizarSolicitacao(int id, SolicitacaoDTO solicitacaoDto);
        Task<SolicitacaoDTO> BuscarPorId(int id);
        Task<ICollection<SolicitacaoDTO>> ListarTodos(int pagina, int tamanhoPagina);
    }
}
