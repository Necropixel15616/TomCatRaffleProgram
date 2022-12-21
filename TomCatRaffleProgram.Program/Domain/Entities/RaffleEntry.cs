using System.Xml.Serialization;

namespace TomCatRaffleProgram.Program.Domain.Entities
{
    [XmlType("Entry")]
    public class RaffleEntry
    {
        public RaffleEntry() { }

        public RaffleEntry(string _firstName, string _lastName, int _tickets)
        {
            this.FirstName = _firstName;
            this.LastName = _lastName;
            this.Tickets = _tickets;
        }

        [XmlAttribute("FirstName")]
        public string FirstName { get; set; }

        [XmlAttribute("LastName")]
        public string LastName { get; set; }

        [XmlElement("Tickets")]
        public int Tickets { get; set; }

    }
}
