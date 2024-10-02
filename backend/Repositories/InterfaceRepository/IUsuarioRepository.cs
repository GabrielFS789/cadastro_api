using backend.Model;

namespace backend.Repositories.InterfaceRepository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> GetById(int id);
        Task<Usuario> Create(Usuario usuario);
        Task<Usuario> Update(Usuario usuario);
        Task<Usuario> Delete(int id);
    }
}
