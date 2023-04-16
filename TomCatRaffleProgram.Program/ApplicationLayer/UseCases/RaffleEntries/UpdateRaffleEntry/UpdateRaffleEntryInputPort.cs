using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.UpdateRaffleEntry
{
    public class UpdateRaffleEntryInputPort : IInputPort<IUpdateRaffleEntryOutputPort>
    {
        public int RaffleId { get; set; }

        public int RaffleEntryId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Tickets { get; set; }
    }
}
