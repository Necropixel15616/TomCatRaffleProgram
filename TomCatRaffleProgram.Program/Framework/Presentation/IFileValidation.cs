using System.Threading;
using System.Threading.Tasks;

namespace TomCatRaffleProgram.Program.Framework.Presentation
{
    public interface IFileValidation
    {

        Task PresentFileNotFoundAsync(CancellationToken cancellationToken);

    }
}
