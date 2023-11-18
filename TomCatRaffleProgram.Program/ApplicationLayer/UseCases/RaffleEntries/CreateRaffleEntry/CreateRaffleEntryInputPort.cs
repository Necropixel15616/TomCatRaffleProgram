using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.CreateRaffleEntry
{
    public class CreateRaffleEntryInputPort : IInputPort<ICreateRaffleEntryOutputPort>
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Tickets { get; set; }

        public int RaffleId { get; set; }

    }
}
