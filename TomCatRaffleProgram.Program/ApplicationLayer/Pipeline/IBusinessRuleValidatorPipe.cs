namespace TomCatRaffleProgram.Program.ApplicationLayer.Pipeline
{
    public interface IBusinessRuleValidatorPipe<TInputPort, TOutportPort> where TInputPort : IInputPortPipe<TOutportPort>
    {

        bool ValidateAsync(TInputPort inputPort, TOutportPort outportPort);

    }
}

