using backend.DataContext;
using backend.Repositories.InterfaceRepository;

namespace backend.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private IEntidadeRepository? _entidadeRepo;
        private IUsuarioRepository? _usuarioRepo;
        private IPerfilAcessoRepository? _perfilAcessoRepo;

        public AppDbContext _context;

        public UnitOfWorkRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEntidadeRepository EntidadeRepository
        {
            get
            {
                return _entidadeRepo = _entidadeRepo ?? new EntidadeRepository(_context);
            }
        }

        public IUsuarioRepository UsuarioRepository
        {
            get {
                return _usuarioRepo = _usuarioRepo ?? new UsuarioRepository(_context);
            }
        }

        public IPerfilAcessoRepository PerfilAcessoRepository
        {
            get
            {
                return _perfilAcessoRepo = _perfilAcessoRepo ?? new PerfilAcessoRepository(_context);
            }
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }


    }
}
