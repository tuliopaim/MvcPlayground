﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MvcPlayground.UI.Models;

namespace MvcPlayground.UI.Controllers
{
    public class BindDeListaController : Controller
    {
        public IActionResult Index()
        {
            return View(new Pessoa
            {
                Nome = "João",
                Sobrenome = "da Silva",
                Idade = 23,
                Enderecos = new List<Endereco>
                {
                    new ()
                    {
                        Cep = "123456",
                        Bairro = "Bairro X",
                        Cidade = "Cidade X",
                        Complemento = "Complemento X",
                        Estado = "XX",
                        Logradouro = "Qd.X Lt.Y Ap.Z"
                    },
                }
            });
        }


        public IActionResult Salvar(Pessoa model)
        {
            if (!ModelState.IsValid) return View(nameof(Index), model);

            return View("Resultado", model);
        }

    }
}