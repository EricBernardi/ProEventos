using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersit : IPalestrantePersist
    {
        private readonly ProEventosContext _context;
        public PalestrantePersit(ProEventosContext context)
        {
            _context = context;

        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(palestrante => palestrante.RedesSociais);
            
            if(includeEventos)
            {
                query = query
                    .Include(palestrante => palestrante.PalestrantesEventos)
                    .ThenInclude(palestranteEventos => palestranteEventos.Evento);
            }

            query = query.OrderBy(palestrante => palestrante.Id);

            return await query.ToArrayAsync(); 
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(palestrante => palestrante.RedesSociais);
            
            if(includeEventos){
                query = query.Include(palestrante => palestrante.PalestrantesEventos)
                .ThenInclude(palestranteEventos => palestranteEventos.Evento);
            }

            query = query.OrderBy(palestrante => palestrante.Id)
                         .Where(palestrante => palestrante.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestrantesByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(palestrante => palestrante.RedesSociais);
            
            if(includeEventos){
                query = query.Include(palestrante => palestrante.PalestrantesEventos)
                .ThenInclude(palestranteEventos => palestranteEventos.Evento);
            }

            query = query.OrderBy(palestrante => palestrante.Id)
                         .Where(palestrante => palestrante.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}