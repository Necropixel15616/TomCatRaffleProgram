using System.Threading;
using System.Threading.Tasks;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Pipeline
{
    public interface IEntityExistenceChecker<TInputPort, TOutputPort> where TInputPort : IInputPort<TOutputPort>
    {

        Task<bool> ValidateEntityExistAsync(TInputPort inputPort, TOutputPort outputPort, CancellationToken cancellationToken);

    }
}
