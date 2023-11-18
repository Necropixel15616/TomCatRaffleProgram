using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.RaffleEntries.GetRaffleEntries
{
    public class GetRaffleEntriesInputPort : IInputPort<IGetRaffleEntriesOutputPort>
    {

        public int RaffleId { get; set; }

    }
}
