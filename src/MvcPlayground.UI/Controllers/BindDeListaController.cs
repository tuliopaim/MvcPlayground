using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MvcPlayground.UI.Models;

namespace MvcPlayground.UI.Controllers
{
    [Route("bind-de-lista")]
    public class BindDeListaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new PessoaModel
            {
                Nome = "João",
                Sobrenome = "da Silva",
                Idade = 23,
                Enderecos = new List<EnderecoModel>
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

        [HttpPost]
        public IActionResult Salvar(PessoaModel model)
        {
            if (!ModelState.IsValid) return View(nameof(Index), model);

            return View("Resultado", model);
        }

    }
}