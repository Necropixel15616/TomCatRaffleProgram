using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.GetRaffleEntries
{
    class GetRaffleEntriesInputPort : IInputPort<IGetRaffleEntriesOutputPort>
    {

        public int RaffleId { get; set; }

    }
}
