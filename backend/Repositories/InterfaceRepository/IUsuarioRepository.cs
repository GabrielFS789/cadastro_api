using backend.Model;

namespace backend.Repositories.InterfaceRepository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task<Usuario> CreateAsync(Usuario usuario);
        Task<Usuario> UpdateAsync(Usuario usuario);
        Task<Usuario> DeleteAsync(int id);
        Task<Usuario> GetByEmailAsync(string email);
    }
}
