using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Services
{
    class StringServices
    {

        private Regex Regex = new Regex(@"\s");

        public bool IsNullOrWhitespaceOrEmpty(string _string)
            => _string.Equals(null) || _string.Equals(string.Empty) || this.Regex.IsMatch(_string);

    }
}
