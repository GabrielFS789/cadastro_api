using backend.DataContext;
using backend.Model;
using backend.Repositories.InterfaceRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class AuthorizationService : AuthorizationHandler<PerfilAcessoRequirement>
    {
        private readonly AppDbContext _context;

        public AuthorizationService(AppDbContext context)
        {
            _context = context;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PerfilAcessoRequirement requirement)
        {
            var perfilId = context.User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value;

            var temPermissao = await _context.PerfilAcesso.AnyAsync(pa => pa.PerfilId == int.Parse(perfilId) && pa.Recurso == requirement.Recurso && pa.Permissao == requirement.Permissao);

            if (temPermissao)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
            
        }
    }
    public class PerfilAcessoRequirement : IAuthorizationRequirement
    {
        public string? Recurso { get; set; }
        public bool Permissao { get; set; }
    }
}
