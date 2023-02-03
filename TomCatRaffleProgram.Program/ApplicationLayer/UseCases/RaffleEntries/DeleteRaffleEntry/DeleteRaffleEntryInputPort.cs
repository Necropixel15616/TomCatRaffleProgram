using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.DeleteRaffleEntry
{
    class DeleteRaffleEntryInputPort : IInputPort<IDeleteRaffleEntryOutputPort>
    {

        public int RaffleId { get; set; }

        public int RaffleEntryId { get; set; }

    }
}
