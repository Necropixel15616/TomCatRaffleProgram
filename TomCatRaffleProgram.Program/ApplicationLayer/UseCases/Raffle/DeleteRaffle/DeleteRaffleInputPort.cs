using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.Raffles.DeleteRaffle
{
    class DeleteRaffleInputPort : IInputPort<IDeleteRaffleOutputPort>
    {

        public int RaffleId { get; set; }

    }
}
