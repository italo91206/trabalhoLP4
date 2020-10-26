using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trabalhoLP4.Models;

namespace trabalhoLP4.Controllers
{
    public class CadastrarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Novo(Models.Usuario usuario)
        {
            if(usuario.Nome != null && usuario.Login != null && usuario.Email != null && usuario.Senha != null){
                
                ViewBag.Logado = 1;
                ViewBag.NomeUsuarioLogado = usuario.Nome;
                return View("~/Views/Produto/Index.cshtml");
            }
            else
            {
                ViewBag.Msg = "Por favor preencha todos os campos";
                return View("~/Views/Cadastrar/Index.cshtml");
            }
        }
    }
}
