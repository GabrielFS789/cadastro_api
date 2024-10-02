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

        public async Task<Usuario> Create(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Delete(int id)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.Id == id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            var usuarios = await _context.Usuario.AsNoTracking().ToListAsync();
            return usuarios;
        }

        public async Task<Usuario> GetById(int id)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.Id == id);
            return usuario;
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            _context.Usuario.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return usuario;

        }
    }
}
