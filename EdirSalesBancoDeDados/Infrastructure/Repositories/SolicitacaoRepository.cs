using EdirSalesBancoDeDados.Domain;
using EdirSalesBancoDeDados.Domain.Interfaces;
using EdirSalesBancoDeDados.Infrastructure.Repositories.ListarTodosPag;
using Microsoft.EntityFrameworkCore;

namespace EdirSalesBancoDeDados.Infrastructure.Repositories
{
    public class SolicitacaoRepository : ISolicitacaoRepository
    {
        private readonly EdirSalesContext _context;
        public SolicitacaoRepository(EdirSalesContext context)
        {
            _context = context;
        }

        public async Task<Solicitacao> Add(Solicitacao solicitacao)
        {
            _context.Solicitacoes.Add(solicitacao);
            await _context.SaveChangesAsync();
            return solicitacao;
        }

        public async Task Delete(Solicitacao solicitacao)
        {
            _context.Solicitacoes.Remove(solicitacao);
            await _context.SaveChangesAsync();
        }

        public async Task<Solicitacao> GetById(int id)
        {
            return await _context.Solicitacoes
                .Include(m => m.Municipes)
                .Include(g => g.Grupos)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Solicitacao>> List(int pagina, int tamanhoPagina)
        {
            return await _context.Solicitacoes
                .Include(m => m.Municipes)
                .Include(g => g.Grupos)
                .AsQueryable()
                .Paginar(pagina, tamanhoPagina);
        }

        public async Task<Solicitacao> Update(Solicitacao solicitacao)
        {
            _context.Solicitacoes.Update(solicitacao);
            await _context.SaveChangesAsync();
            return solicitacao;
        }
    }
}
