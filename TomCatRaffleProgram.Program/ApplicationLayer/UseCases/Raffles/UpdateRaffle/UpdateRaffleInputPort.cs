using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.UpdateRaffle
{
    public class UpdateRaffleInputPort : IInputPort<IUpdateRaffleOutputPort>
    {

        public int RaffleId { get; set; }

        public string Name { get; set; }

    }
}
