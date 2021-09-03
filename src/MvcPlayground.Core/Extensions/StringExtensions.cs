using System.Text.RegularExpressions;

namespace MvcPlayground.Core.Extensions
{
    public static class StringExtensions
    {
        public static string SemFormatacao(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            var rgx = new Regex("[^a-zA-Z0-9]");
            return rgx.Replace(value, "");
        }

        public static string ApenasNumeros(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            var rgx = new Regex("[^0-9]");

            return rgx.Replace(value, "");
        }
    }
}