using System.Threading;
using System.Threading.Tasks;

namespace TomCatRaffleProgram.Program.Framework.Presentation
{
    interface IFileValidation
    {

        Task PresentFileNotFound(CancellationToken cancellationToken);

    }
}
