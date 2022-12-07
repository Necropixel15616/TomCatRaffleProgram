namespace TomCatRaffleProgram.Program.ApplicationLayer.Pipeline
{
    public interface IInputPortValidatorPipe<TInputPort, TOutputPort> where TInputPort : IInputPortPipe<TOutputPort>
    {

        bool ValidateAsync(TInputPort inputPort, TOutputPort outputPort);

    }
}
