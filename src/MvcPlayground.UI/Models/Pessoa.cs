using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcPlayground.UI.Models
{
    public class Pessoa
    {
        [Required(ErrorMessage = "Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [Range(18, 100)]
        public int Idade { get; set; }

        public List<Endereco> Enderecos { get; set; } = new();
    }
}