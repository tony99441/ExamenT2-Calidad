using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repository;
using CalidadT2.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CalidadPruebasT2.TestingControllers
{
    public class LibroControllerTest
    {
        [Test]
        public void JuanEntraDetalleDeUnLibro()
        {
            var usuario = new Usuario();
      
            usuario.Nombres = "Juan";
            usuario.Password = "admin";
            usuario.Username = "admin";
         
            var libromoq = new Mock<ILibroRepository>();
            libromoq.Setup(o => o.DetalleLibro(3)).Returns(new Libro());

            var detalleLibroController = new LibroController(null, null,libromoq.Object,null);
            var guardarCom = detalleLibroController.Details(3);

            Assert.IsInstanceOf<ViewResult>(guardarCom);
        }
        [Test]
        public void JuanAgrecaComentarioLibro()
        {
  
            var usuario = new Usuario();
      
            usuario.Nombres = "Juan";
            usuario.Password = "admin";
            usuario.Username = "admin";
            var userMock = new Mock<IUsuarioRepository>();
            userMock.Setup(o => o.ObtenerUsuarioLoggin(null)).Returns(usuario);

            

            var comentarioMoq = new Mock<IComentarioRepository>();
            comentarioMoq.Setup(o => o.AddComentario(usuario, new Comentario()));
            var cookMock = new Mock<ICookieAuthService>();
   
         
      
            var ComentarioLibroController = new LibroController(userMock.Object, cookMock.Object,null,comentarioMoq.Object);

            var guardarCom = ComentarioLibroController.AddComentario(new Comentario());

            Assert.IsInstanceOf<RedirectToActionResult>(guardarCom);
        }
    }
}