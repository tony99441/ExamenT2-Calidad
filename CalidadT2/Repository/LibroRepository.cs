using System.Collections.Generic;
using System.Linq;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Repository
{
    public interface ILibroRepository
    {
        public List<Libro> Libros();
        public Libro DetalleLibro(int id);
    }
    public class LibroRepository : ILibroRepository
    {
        private AppBibliotecaContext _context;

        public LibroRepository(AppBibliotecaContext context)
        {
            _context = context;
        }
        

        public List<Libro> Libros()
        {
            var model = _context.Libros.Include(o => o.Autor).ToList();
            return model;
        }

        public Libro DetalleLibro(int id)
        {
            var model = _context.Libros
                .Include("Autor")
                .Include("Comentarios.Usuario")
                .FirstOrDefault(o => o.Id == id);
            return model;
        }
    }
}