using System.Threading.Tasks;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Pipeline
{
    public interface IInteractorPipe<TInputPort, TOutputPort> where TInputPort : IInputPort<TOutputPort>
    {

        Task<IViewModel> HandleAsync(TInputPort inputPort, TOutputPort outputPort);

    }
}
