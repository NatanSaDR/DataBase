using EdirSalesBancoDeDados.Application.DTOs;
using EdirSalesBancoDeDados.Application.DTOs.ViewDetailsMunicipe;

namespace EdirSalesBancoDeDados.Application.Interfaces
{
    public interface IMunicipeUseCase
    {
        Task<MunicipeDTO> AddMunicipe(MunicipeDTO municipeDto);
        Task DeletarMunicipe(int id);
        Task<MunicipeDTO> AtualizarMunicipe(int id, MunicipeDTO municipeDto);
        Task<MunicipeDTO> BuscarPorId(int id);
        Task<ICollection<DetalheMunicipe>> ListarTodos(int pagina, int tamanhoPagina);

    }
}
