using backend.Repositories.InterfaceRepository;

namespace backend.Repositories
{
    public class UnitOfWorkRepositoryBase
    {

        public IEntidadeRepository EntidadeRepository
        {
            get
            {
                return _entidadeRepo = _entidadeRepo ?? new EntidadeRepository(_context);
            }
        }

        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                return _usuarioRepo = _usuarioRepo ?? new UsuarioRepository(_context);
            }
        }
    }
}