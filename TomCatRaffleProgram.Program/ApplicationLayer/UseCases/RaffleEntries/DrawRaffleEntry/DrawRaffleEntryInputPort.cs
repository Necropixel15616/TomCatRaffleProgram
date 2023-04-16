using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.DrawRaffleEntry
{
    public class DrawRaffleEntryInputPort : IInputPort<IDrawRaffleEntryOutputPort>
    {

        public int RaffleId { get; set; }

    }
}
