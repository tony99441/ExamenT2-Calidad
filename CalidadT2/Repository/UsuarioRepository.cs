using System.Linq;
using System.Security.Claims;
using CalidadT2.Models;

namespace CalidadT2.Repository
{
    public interface IUsuarioRepository
    {
        public Usuario EncontrarUsuario(string username, string password);
        public Usuario ObtenerUsuarioLoggin(Claim claim);
    }
    public class UsuarioRepository : IUsuarioRepository
    {
        private AppBibliotecaContext _context;

        public UsuarioRepository(AppBibliotecaContext context)
        {
            _context = context;
        }

        public Usuario EncontrarUsuario(string username, string password)
        {
            var usuario = _context.Usuarios.Where(o => o.Username == username && o.Password == password).FirstOrDefault();
            return usuario;
        }

        public Usuario ObtenerUsuarioLoggin(Claim claim)
        {
            var user = _context.Usuarios.FirstOrDefault(o => o.Username == claim.Value);
            return user;
        }
    }
}