using Microsoft.VisualStudio.TestTools.UnitTesting;
using trabalhoLP4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace trabalhoLP4.Models.Tests
{
    [TestClass()]
    public class UsuarioTests
    {
        [TestMethod()]
        public void LogarTest()
        {
            Models.Usuario usuario = new Usuario();
            bool ok = usuario.Logar("adm", "123");

            Assert.IsTrue(ok);
        }
        [TestMethod()]
        public void LogarErradoTest()
        {
            Models.Usuario usuario = new Usuario();
            bool ok = usuario.Logar("adm", "12345");

            Assert.IsFalse(ok);
        }

        [TestMethod()]
        public void ObterTest()
        {
            Models.Usuario usuario = new Usuario();
            bool ok = usuario.Obter(1);
            
            Assert.IsTrue(ok);
        }
    }
}