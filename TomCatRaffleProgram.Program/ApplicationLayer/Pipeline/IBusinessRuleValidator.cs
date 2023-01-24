namespace TomCatRaffleProgram.Program.ApplicationLayer.Pipeline
{
    public interface IBusinessRuleValidator<TInputPort, TOutportPort> where TInputPort : IInputPort<TOutportPort>
    {

        bool ValidateAsync(TInputPort inputPort, TOutportPort outportPort);

    }
}

