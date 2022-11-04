using System;
using System.Collections.Generic;
using System.Text;
using TomCatRaffleProgram.Program.Domain.Entities;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Dtos
{
    class EntryDto
    {
        public EntryDto() { }
        public EntryDto(Entry _entry) 
        {
            this.FirstName = _entry.FirstName;
            this.LastName = _entry.LastName;
            this.Tickets = _entry.Tickets;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Tickets { get; set; }

    }
}
