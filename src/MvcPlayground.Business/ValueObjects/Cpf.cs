using System.Linq;
using MvcPlayground.Core.Extensions;

namespace MvcPlayground.Business.ValueObjects
{
    public readonly struct Cpf
    {
        private readonly string _cpf;

        public bool EhValido => Validar();

        public Cpf(string cpf)
        {
            _cpf = StringExtensions.ApenasNumeros(cpf);
        }

        public static implicit operator Cpf(string value) => new (value);

        public override string ToString() => _cpf;

        public bool Validar()
        {
            if (_cpf is null) return false;
            if (_cpf.Length != 11) return false;
            if (_cpf.Distinct().Count() == 1) return false;

            var cpfSemDigito = _cpf[..9];

            var primeiroDigito = CalcularDigito(cpfSemDigito);
            var segundoDigito = CalcularDigito(cpfSemDigito + primeiroDigito);
            
            return _cpf.EndsWith($"{primeiroDigito}{segundoDigito}");
        }

        private static int CalcularDigito(string cpfTemp)
        {
            var soma = cpfTemp.Select((digito, i) 
                => int.Parse(digito.ToString()) * cpfTemp.Length - i).Sum();

            var resto = soma % 11;
            var digito = resto < 2 ? 0 : 11 - resto;

            return digito;
        }
    }
}