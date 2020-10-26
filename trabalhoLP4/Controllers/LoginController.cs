﻿using System;
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
        public IActionResult Logar([FromBody] Models.Usuario usuario)
        {
            int id = usuario.Logar(usuario.Login, usuario.Senha);
            

            if (id > -1)
            {
                usuario = usuario.Obter(id);
                return Json(new
                {
                    operacao = true,
                    msg = "deu certo...",
                    usuario = Json(usuario)
                }); ;
            }
            else
            {
                return Json(new
                {
                    operacao = false,
                    msg = "deu errado..."
                }); ;
            }
            return View();
        }
    }
}
