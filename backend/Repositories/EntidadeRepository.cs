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
        public async Task<IEnumerable<Entidade>> GetAll()
        {
            var entidades = await _context.Entidade.AsNoTracking().ToListAsync();
            return entidades;
        }
        public async Task<Entidade> GetById(int id) {
            var entidade = await _context.Entidade.FirstOrDefaultAsync(x => x.Id == id);
            if (entidade is null)
                return null;
            return entidade;
        }
        public async Task<Entidade> Create(Entidade newEntidade) 
        {
            try
            {
                var entidadeExiste = await _context.Entidade.FirstOrDefaultAsync(e => e.Codigo == newEntidade.Codigo);
                if (entidadeExiste != null)
                    throw new Exception($"A entidade nome {entidadeExiste.Nome} ja está usando esse código.");
                newEntidade.DataHoraCadastro = DateTime.UtcNow;
                _context.Entidade.Add(newEntidade);
                await _context.SaveChangesAsync();
                return newEntidade;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public async Task<Entidade> Update(Entidade entidade) 
        {
            _context.Entidade.Update(entidade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entidade;
        }
        public async Task<Entidade> Delete(int id) 
        {
            var entidade = await _context.Entidade.FindAsync(id);
            if (entidade is null)
                return null;
            _context.Entidade.Remove(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }
        public async Task<Entidade> GetByCodigo(int codigo)
        {
            var entidade = await _context.Entidade.FirstOrDefaultAsync(x => x.Codigo == codigo);
            if (entidade is null)
                return null;
            return entidade;
        }
    }
}
