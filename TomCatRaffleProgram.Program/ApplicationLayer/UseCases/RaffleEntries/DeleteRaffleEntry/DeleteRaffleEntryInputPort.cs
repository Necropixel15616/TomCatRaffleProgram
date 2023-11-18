using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.DeleteRaffleEntry
{
    public class DeleteRaffleEntryInputPort : IInputPort<IDeleteRaffleEntryOutputPort>
    {

        public int RaffleId { get; set; }

        public int RaffleEntryId { get; set; }

    }
}
