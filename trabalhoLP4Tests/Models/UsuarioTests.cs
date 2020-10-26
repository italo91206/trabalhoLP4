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
            int resposta = usuario.Logar("adm", "123");

            Assert.AreNotSame(-1, resposta);
        }
        [TestMethod()]
        public void LogarErradoTest()
        {
            Models.Usuario usuario = new Usuario();
            int resposta = usuario.Logar("adm", "12345");

            Assert.AreEqual(-1, resposta);
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