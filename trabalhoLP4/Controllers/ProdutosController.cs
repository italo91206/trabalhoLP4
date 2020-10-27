using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace trabalhoLP4.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            Models.Produto produto = new Models.Produto();
            List<Models.Produto> produtos = new List<Models.Produto>();

            produtos = produto.Ler();
            return Json(new
            {
                produtos = produtos
            });
        }
    }
}
