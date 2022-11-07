namespace TomCatRaffleProgram.Program.Domain.Entities
{
    class RaffleEntry
    {
        public RaffleEntry() { }

        public RaffleEntry(string _firstName, string _lastName, int _tickets)
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
