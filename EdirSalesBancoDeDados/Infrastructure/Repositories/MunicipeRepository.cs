using EdirSalesBancoDeDados.Domain;
using EdirSalesBancoDeDados.Domain.Interfaces;
using EdirSalesBancoDeDados.Infrastructure.Repositories.ListarTodosPag;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EdirSalesBancoDeDados.Infrastructure.Repositories
{
    public class MunicipeRepository : IMunicipeRepository
    {
        private readonly EdirSalesContext _context;
        public MunicipeRepository(EdirSalesContext context)
        {
            _context = context;
        }
        public async Task<Municipe> Add(Municipe municipe)
        {
            await _context.Municipes.AddAsync(municipe);
            await _context.SaveChangesAsync();
            return municipe;
        }

        public async Task Delete(Municipe municipe)
        {
            _context.Municipes.Remove(municipe);
            await _context.SaveChangesAsync();

        }

        public async Task<Municipe> GetById(int id)
        {
            return await _context.Municipes.FindAsync(id);
        }
        //esse list vai listar todos os dados incluindo os grupos que cada municipe pertence, porém, paginado
        public async Task<ICollection<Municipe>> List(int pagina, int tamanhoPagina)
        {
            return await _context.Municipes.Include(m => m.Grupos)
                                            .AsQueryable()
                                            .Paginar(pagina, tamanhoPagina);
        }
        public async Task<Municipe> Update(Municipe municipe)
        {
            _context.Municipes.Update(municipe);
            await _context.SaveChangesAsync();
            return municipe;
        }
    }
}
