using System;
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

            foreach (var i in isNotValidChars)
            {
                if (email.Contains(i))
                    return false;
            }
            if (email.Contains("@gmail.com"))
                return true;
            return false;
        }
        public static bool IsNoMoreThenMaxSize(int maxSize, params string[] values)
        {
            foreach (string s in values)
                if (s.Length > maxSize)
                    return false;
            return true;
        }
        public static string GetHashPasword(this string password)
        {
            // Hash the password 
            var hash = new System.Security.Cryptography.SHA256Managed();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hashByte = hash.ComputeHash(bytes);
            return BitConverter.ToString(hashByte).Replace("-", "");

        }
    }
}
