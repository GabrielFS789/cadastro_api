using backend.Model;

namespace backend.Repositories.InterfaceRepository
{
    public interface IEntidadeRepository
    {
        Task<IEnumerable<Entidade>> GetAll();
        Task<Entidade> GetById(int id);
        Task<Entidade> Create(Entidade entidade);
        Task<Entidade> Update(Entidade entidade);
        Task<Entidade> Delete(int id);
        Task<Entidade> GetByCodigo(int codigo);
    }
}
