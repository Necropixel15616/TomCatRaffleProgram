using System.Collections.Generic;
using System.Xml.Serialization;

namespace TomCatRaffleProgram.Program.Domain.Entities
{
    [XmlType("Raffle")]
    public class Raffle
    {
        public Raffle() { }

        public Raffle(string _name, int _id)
        {
            this.Name = _name;
            this.Id = _id;
        }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlArray("Entries")]
        [XmlArrayItem("Entry")]
        public List<RaffleEntry> Entries { get; set; } = new List<RaffleEntry>();

    }
}
