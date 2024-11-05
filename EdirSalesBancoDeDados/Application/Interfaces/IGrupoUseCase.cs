using EdirSalesBancoDeDados.Application.DTOs;
using EdirSalesBancoDeDados.Application.DTOs.ViewDetails;
using EdirSalesBancoDeDados.Domain;

namespace EdirSalesBancoDeDados.Application.Interfaces
{
    public interface IGrupoUseCase
    {
        Task<GrupoDTO> AddGrupo(GrupoDTO grupoDto);
        Task DeletarGrupo(int id);
        Task<GrupoDTO> AtualizarGrupo(int id, GrupoDTO grupoDto);
        Task<GrupoDTO> BuscarPorId(int id);
        Task<IEnumerable<GrupoDTO>> ListarTodos(int pagina, int tamanhoPagina);
        Task<DetalheGrupoDTO> DetalhesDoGrupo(int id);

    }
}
