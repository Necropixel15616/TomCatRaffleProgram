using System;
using System.Collections.Generic;
using System.Text;

namespace TomCatRaffleProgram.Program.Domain.Entities
{
    class Raffle
    {
        public Raffle() { }

        public Raffle(string _name, int _id)
        {
            this.Name = _name;
            this.Id = _id;
        }

        public string Name { get; set; }

        public int Id { get; set; }

    }
}
