using System;
using System.Linq;
using CalidadT2.Models;

namespace CalidadT2.Repository
{
    public interface IComentarioRepository
    {
        public void AddComentario(Usuario user, Comentario comentario);
    }
    public class ComentarioRepository : IComentarioRepository
    {
        private AppBibliotecaContext _context;

        public ComentarioRepository(AppBibliotecaContext context)
        {
            _context = context;
        }

        public void AddComentario(Usuario user, Comentario comentario)
        {
            comentario.UsuarioId = user.Id;
            comentario.Fecha = DateTime.Now;
            _context.Comentarios.Add(comentario);

            var libro = _context.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

            _context.SaveChanges();
        }
    }
}