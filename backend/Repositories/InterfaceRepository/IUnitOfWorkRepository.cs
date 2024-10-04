namespace backend.Repositories.InterfaceRepository
{
    public interface IUnitOfWorkRepository
    {
        IEntidadeRepository EntidadeRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        IPerfilAcessoRepository PerfilAcesso { get;  }
        Task CommitAsync();
    }
}
