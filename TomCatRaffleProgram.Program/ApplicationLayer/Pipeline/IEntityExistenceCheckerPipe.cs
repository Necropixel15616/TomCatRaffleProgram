namespace TomCatRaffleProgram.Program.ApplicationLayer.Pipeline
{
    public interface IEntityExistenceCheckerPipe<TInputPort, TOutputPort> where TInputPort : IInputPort<TOutputPort>
    {

        bool ValidateEntityExistAsync(TInputPort inputPort, TOutputPort outputPort);

    }
}
