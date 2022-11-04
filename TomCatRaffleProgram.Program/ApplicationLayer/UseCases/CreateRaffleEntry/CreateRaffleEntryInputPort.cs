using System;
using System.Collections.Generic;
using System.Text;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffleEntry
{
    class CreateRaffleEntryInputPort
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Tickets { get; set; }

    }
}
