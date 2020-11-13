using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace trabalhoLP4.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar([FromBody] Models.Categoria categoria)
        {
            if(categoria.Cadastrar() == 1)
            {
                return Json(new
                {
                    operacao = true,
                    msg = "deu certo...",
                });
            }
            else
            {
                return Json(new
                {
                    operacao = false,
                    msg = "deu errado...",
                });
            }
        }

        public IActionResult Listar()
        {
            Models.Categoria categoria = new Models.Categoria();
            List<Models.Categoria> categorias = new List<Models.Categoria>();

            categorias = categoria.Ler();
            return Json(new
            {
                operacao = true,
                msg = "Deu certo...",
                categorias = categorias
            });
        }
    }
}
