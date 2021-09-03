using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MvcPlayground.UI.Extensions;

namespace MvcPlayground.UI.Models
{
    public class PessoaModel
    {
        [Cpf]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [Range(18, 100)]
        public int Idade { get; set; }

        public List<EnderecoModel> Enderecos { get; set; } = new();
    }
}