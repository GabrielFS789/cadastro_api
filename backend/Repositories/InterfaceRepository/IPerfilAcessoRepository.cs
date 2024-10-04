using backend.Model;

namespace backend.Repositories.InterfaceRepository
{
    public interface IPerfilAcessoRepository
    {
        Task<PerfilAcesso> GetById(int id);
    }
}
