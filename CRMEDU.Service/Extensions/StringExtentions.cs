using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CRMEDU.Service.Extensions
{
    public static class StringExtentions
    {
        public static bool IsValidPassword(this string pasword)
        {
            Regex regex = new Regex(@"^(.{8,}|[^0-9]*|[^A-Z])$");
            Match match = regex.Match(pasword);
            return match.Success;
        }
        public static bool IsValidEmail(this string email)
        {
            var isNotValidChars = @"!__#__$__%__^__&__*__(__)__=__-__+__?__/__,__>__<__|__\__`__~__ ".Split("__");

            return !isNotValidChars.Any(email.Contains) && email.Contains("@gmail.com");
        }
        public static bool IsNoMoreThenMaxSize(int maxSize, params string[] values)
            => values.All(v => v.Length <= maxSize);

        public static string GetHashPasword(this string password)
        {
            var hash = new System.Security.Cryptography.SHA256Managed();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hashByte = hash.ComputeHash(bytes);
            return BitConverter.ToString(hashByte).Replace("-", "");

        }
    }
}
