using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repository;
using CalidadT2.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CalidadPruebasT2.TestingControllers
{
    public class AuthControllerTest
    {
        [Test]
        public void UsuarioJuanSeLoguea()
        {
            var usuario = new Usuario();
      
            usuario.Nombres = "Juan";
            usuario.Password = "admin";
            usuario.Username = "admin";
       

            var userMock = new Mock<IUsuarioRepository>();
            userMock.Setup(o => o.EncontrarUsuario(usuario.Username, usuario.Password)).Returns(usuario);

            var cookMock = new Mock<ICookieAuthService>();

            var authCont = new AuthController(userMock.Object, cookMock.Object);
            var log = authCont.Login("admin", "admin");

            Assert.IsInstanceOf<RedirectToActionResult>(log);
        }
    }
}