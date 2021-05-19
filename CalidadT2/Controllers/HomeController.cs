using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalidadT2.Models;
using CalidadT2.Repository;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    public class HomeController : Controller
    {
     
        private readonly ILibroRepository _libro;

        public HomeController(ILibroRepository libro)
        {
            _libro = libro;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _libro.Libros();
            return View(model);
        }
    }
}
