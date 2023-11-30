using Usuarios.Models;

namespace Usuarios.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetUsuario();

        Task<Usuario> GetUsuario(int Id);

        Task<IEnumerable<Usuario>> GetUsuariosByNome(string nome);

        Task CreateUsuario(Usuario usuario);

        Task UpdateUsuario(Usuario usuario);

        Task DeleteUsuario(Usuario usuario);
    }
}
