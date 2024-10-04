using backend.DataContext;
using backend.Model;
using backend.Repositories.InterfaceRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            try
            {
                var usuarioExiste = await _context.Usuario.FirstOrDefaultAsync(x => x.Email == usuario.Email);
                if (usuarioExiste != null)
                    throw new Exception($"O usuario {usuarioExiste.Nome} já está com esse email cadastrado");
                await _context.Usuario.AddAsync(usuario);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario> DeleteAsync(int id)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.Id == id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            var usuarios = await _context.Usuario.AsNoTracking().ToListAsync();
            return usuarios;
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.Id == id);
            return usuario;
        }

        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            _context.Usuario.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            var usuario = _context.Usuario.FirstOrDefault(x => x.Email == email);
            return usuario;
        }
    }
}
