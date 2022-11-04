using System;
using System.Collections.Generic;
using System.Text;

namespace TomCatRaffleProgram.Program.Domain.Entities
{
    class Entry
    {
        public Entry() { }

        public Entry(string _firstName, string _lastName, int _tickets)
        {
            this.FirstName = _firstName;
            this.LastName = _lastName;
            this.Tickets = _tickets;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Tickets { get; set; }

    }
}
