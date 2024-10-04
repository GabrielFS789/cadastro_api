using backend.DTOs;

namespace backend.Services.Interface
{
    public interface ITokenService
    {
        Task<string> GerarToken(LoginDTO login);
    }
}
