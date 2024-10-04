using backend.DataContext;
using backend.Model;
using backend.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class EntidadeRepository : IEntidadeRepository
    {
        private readonly AppDbContext _context;

        public EntidadeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Entidade>> GetAllAsync()
        {
            var entidades = await _context.Entidade.AsNoTracking().ToListAsync();
            return entidades;
        }
        public async Task<Entidade> GetByIdAsync(int id) {
            var entidade = await _context.Entidade.FirstOrDefaultAsync(x => x.Id == id);
            if (entidade is null)
                return null;
            return entidade;
        }
        public async Task<Entidade> CreateAsync(Entidade newEntidade) 
        {
            try
            {
                var entidadeExiste = await _context.Entidade.FirstOrDefaultAsync(e => e.Codigo == newEntidade.Codigo);
                if (entidadeExiste != null)
                    throw new Exception($"A entidade nome {entidadeExiste.Nome} ja está usando esse código.");
                newEntidade.UpdateDataHoraCadastro();
                _context.Entidade.Add(newEntidade);
                return newEntidade;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public Entidade Update(Entidade entidade) 
        {
            entidade.UpdateDataHoraUltimaAlteracao();
            _context.Entidade.Entry(entidade).State = EntityState.Modified;
            try
            {
                return entidade;
            }
            catch (DbUpdateException ex)
            {
                
                throw new DbUpdateException(ex.Message);
            }
        }
        public async Task<Entidade> DeleteAsync(int id) 
        {
            var entidade = await _context.Entidade.FindAsync(id);
            if (entidade is null)
                return null;
            _context.Entidade.Remove(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }
        public async Task<Entidade> GetByCodigoAsync(int codigo)
        {
            var entidade = await _context.Entidade.FirstOrDefaultAsync(x => x.Codigo == codigo);
            if (entidade is null)
                return null;
            return entidade;
        }
    }
}
