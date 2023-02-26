using System.Threading;
using System.Threading.Tasks;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Pipeline
{
    public interface IBusinessRuleValidator<TInputPort, TOutportPort> where TInputPort : IInputPort<TOutportPort>
    {

        Task<bool> ValidateAsync(TInputPort inputPort, TOutportPort outportPort, CancellationToken cancellationToken);

    }
}

