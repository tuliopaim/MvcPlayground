using System.ComponentModel.DataAnnotations;
using MvcPlayground.Core.ValueObjects;

namespace MvcPlayground.Core.Extensions
{
    public class CpfAttribute : ValidationAttribute
    {
        public const string CampoObrigatorio = "Campo obrigatório";
        public const string CpfInvalido = "CPF inválido";
        public bool Obrigatorio { get; set; }

        public CpfAttribute(bool obrigatorio = true)
        {
            Obrigatorio = obrigatorio;
        }
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!Obrigatorio && string.IsNullOrEmpty(value?.ToString()))
                return ValidationResult.Success;

            if (string.IsNullOrEmpty(value?.ToString()))
                return new ValidationResult(CampoObrigatorio);

            return new Cpf(value.ToString()).EhValido
                ? ValidationResult.Success
                : new ValidationResult(CpfInvalido);
        }
    }
}