using System.Security.Claims;
using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repository;
using CalidadT2.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CalidadPruebasT2.TestingControllers
{
    public class BibliotecaControllerTest
    {
        [Test]
        public void UsuarioEntraAlIndex()
        {
  
         
            var userMock = new Mock<IUsuarioRepository>();
            userMock.Setup(o => o.ObtenerUsuarioLoggin(null)).Returns(new Usuario() { });

            

            var bibliMoq = new Mock<IBibliotecaRepository>();
            bibliMoq.Setup(o => o.misBibliotecas(new Usuario()));
            var cookMock = new Mock<ICookieAuthService>();
         

            var indexBibliotecaController = new BibliotecaController(userMock.Object, cookMock.Object,bibliMoq.Object);
            var guardarCom = indexBibliotecaController.Index();

            Assert.IsInstanceOf<ViewResult>(guardarCom);
        }
        [Test]
        public void JuanAgregaLibroAlaBiblioteca()
        {
  
            var usuario = new Usuario();
      
            usuario.Nombres = "Juan";
            usuario.Password = "admin";
            usuario.Username = "admin";
            var userMock = new Mock<IUsuarioRepository>();
            userMock.Setup(o => o.ObtenerUsuarioLoggin(null)).Returns(usuario);

            

            var bibliMoq = new Mock<IBibliotecaRepository>();
            bibliMoq.Setup(o => o.AgregarBiblioteca(usuario, 3));
            var cookMock = new Mock<ICookieAuthService>();
   
         
        
            var AgregarLibroBibliotecaController = new BibliotecaController(userMock.Object, cookMock.Object,bibliMoq.Object);
            
            var guardarCom = AgregarLibroBibliotecaController.Add(3);

            Assert.IsInstanceOf<RedirectToActionResult>(guardarCom);
        }
        
        [Test]
        public void JuanMarcaComoLeidoUnLibro()
        {
  
            var usuario = new Usuario();
      
            usuario.Nombres = "Juan";
            usuario.Password = "admin";
            usuario.Username = "admin";
            var userMock = new Mock<IUsuarioRepository>();
            userMock.Setup(o => o.ObtenerUsuarioLoggin(null)).Returns(usuario);

            

            var bibliMoq = new Mock<IBibliotecaRepository>();
            bibliMoq.Setup(o => o.MarcarLeido(usuario, 3));
            var cookMock = new Mock<ICookieAuthService>();
   
         
        
            var MarcarLeidoBibliotecaController = new BibliotecaController(userMock.Object, cookMock.Object,bibliMoq.Object);
            
            var guardarCom = MarcarLeidoBibliotecaController.MarcarComoLeyendo(3);

            Assert.IsInstanceOf<RedirectToActionResult>(guardarCom);
        }
        
        [Test]
        public void JuanMarcaComoTerminadoUnLibro()
        {
  
            var usuario = new Usuario();
      
            usuario.Nombres = "Juan";
            usuario.Password = "admin";
            usuario.Username = "admin";
            var userMock = new Mock<IUsuarioRepository>();
            userMock.Setup(o => o.ObtenerUsuarioLoggin(null)).Returns(usuario);

            

            var bibliMoq = new Mock<IBibliotecaRepository>();
            bibliMoq.Setup(o => o.MarcarComoTerminado(usuario, 3));
            var cookMock = new Mock<ICookieAuthService>();
   
         
        
            var MarcarTerminadoBibliotecaController = new BibliotecaController(userMock.Object, cookMock.Object,bibliMoq.Object);
            
            var guardarCom = MarcarTerminadoBibliotecaController.MarcarComoTerminado(3);

            Assert.IsInstanceOf<RedirectToActionResult>(guardarCom);
        }
        

    }
}