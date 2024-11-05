namespace EdirSalesBancoDeDados.Domain.Interfaces
{
    public interface ISolicitacaoRepository
    {
        Task<Solicitacao> Add(Solicitacao solicitacao);
        Task<Solicitacao> GetById(int id);
        Task<IEnumerable<Solicitacao>> List(int pagina, int tamanhoPagina);
        Task Delete(Solicitacao solicitacao);
        Task<Solicitacao> Update(Solicitacao solicitacao);
    }
}
