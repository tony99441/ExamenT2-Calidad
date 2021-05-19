using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CalidadPruebasT2.TestingControllers
{
    public class HomeControllerTest
    {
        [Test]
        public void UsuarioEntraAlIndex()
        {


            var libroMoq = new Mock<ILibroRepository>();
            libroMoq.Setup(o => o.Libros()).Returns(new List<Libro>());





            var indexHomeController = new HomeController(libroMoq.Object);
            var guardarCom = indexHomeController.Index();

            Assert.IsInstanceOf<ViewResult>(guardarCom);
        }
    }
}