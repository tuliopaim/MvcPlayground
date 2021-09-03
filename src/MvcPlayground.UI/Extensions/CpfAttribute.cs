using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using MvcPlayground.Business.ValueObjects;

namespace MvcPlayground.UI.Extensions
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

    public class CpfAttributeAdapter : AttributeAdapterBase<CpfAttribute>
    {
        public CpfAttributeAdapter(CpfAttribute attribute,
            IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer)
        {
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-cpf", GetErrorMessage(context));
            var obrigatorio = Attribute.Obrigatorio.ToString();
            MergeAttribute(context.Attributes, "data-val-cpf-obrigatorio", obrigatorio);
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext) =>
            CpfAttribute.CpfInvalido;
    }
}