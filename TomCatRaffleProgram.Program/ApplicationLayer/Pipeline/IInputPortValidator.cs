using System.Threading;
using System.Threading.Tasks;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Pipeline
{
    public interface IInputPortValidator<TInputPort, TOutputPort> where TInputPort : IInputPort<TOutputPort>
    {

        Task<bool> ValidateAsync(TInputPort inputPort, TOutputPort outputPort, CancellationToken cancellationToken);

    }
}
