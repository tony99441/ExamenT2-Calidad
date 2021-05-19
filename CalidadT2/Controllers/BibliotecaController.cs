using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalidadT2.Constantes;
using CalidadT2.Models;
using CalidadT2.Repository;
using CalidadT2.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    [Authorize]
    public class BibliotecaController : Controller
    {
       
        private readonly IUsuarioRepository _usuario;
        private readonly ICookieAuthService _cookieAuthService;
        private readonly IBibliotecaRepository _biblioteca;


        public BibliotecaController(IUsuarioRepository usuario, ICookieAuthService cookieAuthService, IBibliotecaRepository biblioteca)
        {
            _usuario = usuario;
            _cookieAuthService = cookieAuthService;
            _biblioteca = biblioteca;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Usuario user = LoggedUser();

            var model = _biblioteca.misBibliotecas(user);

            return View(model);
        }

        [HttpGet]
        public ActionResult Add(int libro)
        {
            Usuario user = LoggedUser();

        _biblioteca.AgregarBiblioteca(user,libro);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MarcarComoLeyendo(int libroId)
        {
            Usuario user = LoggedUser();

            _biblioteca.MarcarLeido(user,libroId);

         
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarcarComoTerminado(int libroId)
        {
            Usuario user = LoggedUser();

        _biblioteca.MarcarComoTerminado(user,libroId);

          
            return RedirectToAction("Index");
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
