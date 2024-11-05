using EdirSalesBancoDeDados.Domain;
using EdirSalesBancoDeDados.Domain.Interfaces;
using EdirSalesBancoDeDados.Infrastructure.Repositories.ListarTodosPag;
using Microsoft.EntityFrameworkCore;

namespace EdirSalesBancoDeDados.Infrastructure.Repositories
{
    public class GrupoRepository : IGrupoRepository
    {
        private readonly EdirSalesContext _context;
        public GrupoRepository(EdirSalesContext context)
        {
            _context = context;
        }
        public async Task<Grupo> Add(Grupo grupo)
        {
            await _context.Grupos.AddAsync(grupo);
            await _context.SaveChangesAsync();
            return grupo;
        }

        public async Task Delete(Grupo grupo)
        {
            _context.Grupos.Remove(grupo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Grupo>> List(int pagina, int tamanhoPagina)
        {
            return await _context.Grupos.AsQueryable().Paginar(pagina, tamanhoPagina);
        }

        public async Task<Grupo> Update(Grupo grupo)
        {
            _context.Grupos.Update(grupo);
            await _context.SaveChangesAsync();
            return grupo;
        }

        public async Task<Grupo> GetById(int id)
        {
            return await _context.Grupos.FindAsync(id);
        }

        public async Task<Grupo> DetalhesDoGrupo(int id)
        {
            return await _context.Grupos
                .Include(g => g.Municipes) // Inclui os munícipes relacionados ao grupo
                .FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
