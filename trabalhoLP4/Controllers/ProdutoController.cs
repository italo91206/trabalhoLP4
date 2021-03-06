﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace trabalhoLP4.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar([FromBody] Models.Produto produto)
        {
            if(produto.Cadastrar() == 1)
                return Json(new
                {
                    operacao = true,
                    msg = "deu certo...",
                }); 
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
            Models.Produto produto = new Models.Produto();
            List<Models.Produto> produtos = new List<Models.Produto>();

            produtos = produto.Ler();
            return Json(new
            {
                operacao = true,
                msg = "Deu certo...",
                produtos = produtos
            });
        }

        public IActionResult ListarCategorias()
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
