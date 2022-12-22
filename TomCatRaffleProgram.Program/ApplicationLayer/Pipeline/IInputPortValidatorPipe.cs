namespace TomCatRaffleProgram.Program.ApplicationLayer.Pipeline
{
    public interface IInputPortValidatorPipe<TInputPort, TOutputPort> where TInputPort : IInputPort<TOutputPort>
    {

        bool ValidateAsync(TInputPort inputPort, TOutputPort outputPort);

    }
}
