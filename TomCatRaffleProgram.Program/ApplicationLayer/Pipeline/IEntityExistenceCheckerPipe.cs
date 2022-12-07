namespace TomCatRaffleProgram.Program.ApplicationLayer.Pipeline
{
    public interface IEntityExistenceCheckerPipe<TInputPort, TOutputPort> where TInputPort : IInputPortPipe<TOutputPort>
    {

        bool ValidateEntityExistAsync(TInputPort inputPort, TOutputPort outputPort);

    }
}
