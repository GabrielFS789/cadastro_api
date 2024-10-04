using backend.Model;

namespace backend.Repositories.InterfaceRepository
{
    public interface IEntidadeRepository
    {
        Task<IEnumerable<Entidade>> GetAllAsync();
        Task<Entidade> GetByIdAsync(int id);
        Task<Entidade> CreateAsync(Entidade entidade);
        Entidade Update(Entidade entidade);
        Task<Entidade> DeleteAsync(int id);
        Task<Entidade> GetByCodigoAsync(int codigo);
    }
}
