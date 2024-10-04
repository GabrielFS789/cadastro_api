using backend.DataContext;
using backend.Model;
using backend.Repositories.InterfaceRepository;

namespace backend.Repositories
{
    public class PerfilAcessoRepository : IPerfilAcessoRepository
    {
        private readonly AppDbContext _context;

        public PerfilAcessoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<PerfilAcesso> GetById(int id)
        {
            return await _context.PerfilAcesso.FindAsync(id);
        }
    }
}
