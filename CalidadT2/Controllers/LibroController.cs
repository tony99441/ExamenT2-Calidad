using System;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Repository;
using CalidadT2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    public class LibroController : Controller
    {
 
        private readonly IUsuarioRepository _usuario;
        private readonly ICookieAuthService _cookieAuthService;
        private readonly ILibroRepository _libro;
        private readonly IComentarioRepository _comentario ;

        public LibroController(IUsuarioRepository usuario, ICookieAuthService cookieAuthService, ILibroRepository libro, IComentarioRepository comentario)
        {
            _usuario = usuario;
            _cookieAuthService = cookieAuthService;
            _libro = libro;
            _comentario = comentario;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _libro.DetalleLibro(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddComentario(Comentario comentario)
        {
            Usuario user = LoggedUser();
            _comentario.AddComentario(user,comentario);

            return RedirectToAction("Details", new { id = comentario.LibroId });
        }

        private Usuario LoggedUser()
        {
            _cookieAuthService.SetHttpContext(HttpContext);
            var claim = _cookieAuthService.ObetenerClaim();
            var user = _usuario.ObtenerUsuarioLoggin(claim);
            return user;
        }
    }
}
