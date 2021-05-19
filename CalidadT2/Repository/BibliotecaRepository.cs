using System.Collections.Generic;
using System.Linq;
using CalidadT2.Constantes;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Repository
{
    public interface IBibliotecaRepository
    {
        public List<Biblioteca> misBibliotecas(Usuario user);
        public void AgregarBiblioteca(Usuario user,int libro);
        public void MarcarLeido(Usuario user, int libroId);
        public void MarcarComoTerminado(Usuario user, int libroId);
    }
    public class BibliotecaRepository : IBibliotecaRepository
    {
        private AppBibliotecaContext _context;

        public BibliotecaRepository(AppBibliotecaContext context)
        {
            _context = context;
        }

        public List<Biblioteca> misBibliotecas(Usuario user)
        {
            var model = _context.Bibliotecas
                .Include(o => o.Libro.Autor)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == user.Id)
                .ToList();
            return model;
        }

        public void AgregarBiblioteca(Usuario user,int libro)
        {
            var biblioteca = new Biblioteca
            {
                LibroId = libro,
                UsuarioId = user.Id,
                Estado = ESTADO.POR_LEER
            };

            _context.Bibliotecas.Add(biblioteca);
            _context.SaveChanges();
        }

        public void MarcarLeido(Usuario user, int libroId)
        {
            var libro = _context.Bibliotecas
                .FirstOrDefault(o => o.LibroId == libroId && o.UsuarioId == user.Id);

            libro.Estado = ESTADO.LEYENDO;
            _context.SaveChanges();
        }

        public void MarcarComoTerminado(Usuario user, int libroId)
        {
            var libro = _context.Bibliotecas
                .FirstOrDefault(o => o.LibroId == libroId && o.UsuarioId == user.Id);

            libro.Estado = ESTADO.TERMINADO;
            _context.SaveChanges();
        }
    }
}