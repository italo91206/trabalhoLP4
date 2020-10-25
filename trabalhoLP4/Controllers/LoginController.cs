using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace trabalhoLP4.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logar([FromBody] string usuario, string senha)
        {
            //if(usuario != "admin" || senha != "123")
            //{
            //    ViewBag.Msg = "Usuário e Senha não são válidos.";
            //    return View("Index");
            //}
            //else
            //{
                ViewBag.NomeUsuarioLogado = "administrador";
                ViewBag.Logado = 1;

                return Json(new
                {
                    operacao = true,
                    msg = "deu certo..."
                }); ;
            //}
        }
    }
}
