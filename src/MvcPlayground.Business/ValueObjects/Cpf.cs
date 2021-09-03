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

            var primeiroDigito = CalcularPrimeiroDigito(cpfSemDigito);
            var segundoDigito = CalcularSegundoDigito(cpfSemDigito, primeiroDigito);
            
            return _cpf.EndsWith($"{primeiroDigito}{segundoDigito}");
        }

        private static int CalcularPrimeiroDigito(string cpfSemDigito)
        {
            var multiplicador1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(cpfSemDigito[i].ToString()) * multiplicador1[i];

            var resto = soma % 11;
            var digito = resto < 2 ? 0 : 11 - resto;

            return digito;
        }
        
        private static int CalcularSegundoDigito(string cpfSemDigito, int primeiroDigito)
        {
            var multiplicador2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var cpfTemporario = cpfSemDigito + primeiroDigito;

            var soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse(cpfTemporario[i].ToString()) * multiplicador2[i];

            var resto = soma % 11;
            var digito = resto < 2 ? 0 : 11 - resto;

            return digito;
        }

    }
}