using System.ComponentModel.DataAnnotations;

namespace MvcPlayground.UI.Models
{
    public class EnderecoModel
    {
        [Required(ErrorMessage = "Obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public string Estado { get; set; }
    }
}