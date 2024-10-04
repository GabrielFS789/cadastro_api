using backend.DTOs;
using backend.Repositories.InterfaceRepository;
using backend.Services.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        private readonly IUnitOfWorkRepository _unitOfWorkRepository;

        public TokenService (IConfiguration configuration, IUnitOfWorkRepository unitOfWorkRepository)
        {
            _configuration = configuration;
            _unitOfWorkRepository = unitOfWorkRepository;
        }

        public async Task<string> GerarToken(LoginDTO login)
        {
            var usuario = await _unitOfWorkRepository.UsuarioRepository.GetByEmailAsync(login.Email);
            if (usuario is null || !Criptografia.Compara(login.Password, usuario.Password) || usuario.Email != login.Email)
            {
                return null;
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwtkey:secretKey"] ?? string.Empty));
            var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var issuer = _configuration["Jwtkey:issuer"] ?? string.Empty;
            var audience = _configuration["Jwtkey:audience"] ?? string.Empty;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nome ?? string.Empty),
                new Claim(ClaimTypes.Role, usuario.PerfilId.ToString() ?? "0")
            };

            var tokenOptions = new JwtSecurityToken(
                issuer, 
                audience, 
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signInCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
