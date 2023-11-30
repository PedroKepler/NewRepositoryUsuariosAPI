using Usuarios.Context;
using Usuarios.Models;
using Microsoft.EntityFrameworkCore;

namespace Usuarios.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsuario()
        {
            try
            {
                return await _context.UsuariosAPI.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateUsuario(Usuario usuario)
        {
            _context.UsuariosAPI.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            Usuario usuario = await _context.UsuariosAPI.FindAsync(id);
            return usuario;
        }

        public async Task DeleteUsuario(Usuario usuario)
        {
            _context.UsuariosAPI.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosByNome(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome))
            {
                var usuarios = await _context.UsuariosAPI.Where(n => n.Nome.Contains(nome)).ToListAsync();
                return usuarios;
            }
            else
            {
                var usuarios = await GetUsuario();
                return usuarios;
            }
        }

        public Task DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
