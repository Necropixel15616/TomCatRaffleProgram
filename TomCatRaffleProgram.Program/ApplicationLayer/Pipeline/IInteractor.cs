using System.Threading.Tasks;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Pipeline
{
    public interface IInteractor<TInputPort, TOutputPort> where TInputPort : IInputPort<TOutputPort>
    {

        Task HandleAsync(TInputPort inputPort, TOutputPort outputPort);

    }
}
