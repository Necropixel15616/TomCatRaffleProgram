using System.Threading.Tasks;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Pipeline
{
    public interface IInteractorPipe<TInputPort, TOutputPort> where TInputPort : IInputPort<TOutputPort>
    {

        Task HandleAsync(TInputPort inputPort, TOutputPort outputPort);

    }
}
