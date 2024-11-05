using EdirSalesBancoDeDados.Application.DTOs;

namespace EdirSalesBancoDeDados.Domain.Interfaces
{
    public interface IMunicipeRepository
    {
        public Task<Municipe> Add(Municipe municipe);
        public Task<Municipe> GetById(int id);
        public Task<ICollection<Municipe>>List(int pagina, int tamanhoPagina);
        public Task Delete(Municipe municipe);
        public Task<Municipe> Update(Municipe municipe);
    }
}
