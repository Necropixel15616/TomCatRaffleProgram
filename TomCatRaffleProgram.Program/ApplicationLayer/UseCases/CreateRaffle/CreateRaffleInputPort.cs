using TomCatRaffleProgram.Program.ApplicationLayer.Pipeline;

namespace TomCatRaffleProgram.Program.ApplicationLayer.UseCases.CreateRaffle
{
    class CreateRaffleInputPort : IInputPort<ICreateRaffleOutputPort>
    {

        public string RaffleName { get; set; }

    }
}
