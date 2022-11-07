using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Services
{
    static class StringExtensions
    {

        private static readonly Regex Regex = new Regex(@"\s");

        public static bool IsNullOrWhitespaceOrEmpty(this string _string)
            => _string.Equals(null) || _string.Equals(string.Empty) || Regex.IsMatch(_string);

    }
}
