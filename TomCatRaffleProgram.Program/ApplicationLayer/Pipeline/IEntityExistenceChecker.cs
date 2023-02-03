namespace TomCatRaffleProgram.Program.ApplicationLayer.Pipeline
{
    public interface IEntityExistenceChecker<TInputPort, TOutputPort> where TInputPort : IInputPort<TOutputPort>
    {

        bool ValidateEntityExist(TInputPort inputPort, TOutputPort outputPort);

    }
}
