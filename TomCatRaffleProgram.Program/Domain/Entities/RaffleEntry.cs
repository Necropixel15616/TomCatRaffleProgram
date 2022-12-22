using System.Xml.Serialization;

namespace TomCatRaffleProgram.Program.Domain.Entities
{
    [XmlType("Entry")]
    public class RaffleEntry
    {
        public RaffleEntry() { }

        public RaffleEntry(int _id, string _firstName, string _lastName, int _tickets)
        {
            Id = _id;
            FirstName = _firstName;
            LastName = _lastName;
            Tickets = _tickets;
        }

        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlAttribute("FirstName")]
        public string FirstName { get; set; }

        [XmlAttribute("LastName")]
        public string LastName { get; set; }

        [XmlElement("Tickets")]
        public int Tickets { get; set; }
    }
}
