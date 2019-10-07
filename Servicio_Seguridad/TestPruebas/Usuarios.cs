using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SS_Logica;
using SS_Modelo;

namespace TestPruebas
{
    [TestClass]
    public class Usuarios
    {
        [TestMethod]
        public void Usuario_Registrar()
        {
            String estadoCorrecto = LNUsuario.Usuario_Registrar("TesPrueba", "tes1", "tes2", "TesPrueba", "tes@hotmail.com", "ESUSAC", "Administrador");

            Assert.AreEqual(estadoCorrecto.Substring(0, 6), "[CREO]");
        }
        [TestMethod]
        public void Usuario_RegistrarDuplisitada()
        {
            String estadoCorrecto = LNUsuario.Usuario_Registrar("TesPrueba", "tes1", "tes2", "testprueba", "tes@hotmail.com", "ESUSAC", "Administrador");

            Assert.AreEqual(estadoCorrecto.Substring(0, 7), "[ERROR]");
        }

        [TestMethod]
        public void Usuario_FaltaParametrosPrincipal()
        {
            String estadoCorrecto = LNUsuario.Usuario_Registrar("", "tes1", "sdf", "testprueba", "tes@hotmail.com", "ESUSAC", "Administrador");

            Assert.AreEqual(estadoCorrecto.Substring(0, 7), "[ERROR]");
        }
        [TestMethod]
        public void Usuario_Actualizar()
        {
            String estadoCorrecto = LNUsuario.Usuario_Modificar("TesPrueba", "tes1", "tes2", "testprueba", "tes@hotmail.com", "ESUSAC", "Administrador");

            Assert.AreEqual(estadoCorrecto, "");
        }
        [TestMethod]
        public void Usuario_ActualizarFaltaParametroIdentificacdor()
        {
            String estadoCorrecto = LNUsuario.Usuario_Modificar("", "tes1", "tes2", "testprueba", "tes@hotmail.com", "ESUSAC", "Administrador");
            Assert.AreEqual(estadoCorrecto.Substring(0, 7), "[ERROR]");
        }

        [TestMethod]
        public void Usuario_IniciarSession()
        {

            Usuario usu = new Usuario();
            usu = LNUsuario.Usuario_Iniciar_Sesion("TesPrueba", "TesPrueba");
            Assert.IsNotNull(usu.IdUsuario);
        }
        [TestMethod]
        public void Usuario_IniciarSessionIncorrecto()
        {

            Usuario usu = new Usuario();
            usu = LNUsuario.Usuario_Iniciar_Sesion("TesPrueba", "");

            Assert.IsNull(usu.IdUsuario);
        }
        [TestMethod]
        public void Usuario_EliminarExistente()
        {
            String usu = LNUsuario.Usuario_Eliminar("TesPrueba");
            Assert.AreEqual(usu, "");
        }       

    }
}
