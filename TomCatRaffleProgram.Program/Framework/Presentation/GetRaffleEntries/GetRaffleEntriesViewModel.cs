using System.Collections.Generic;
using TomCatRaffleProgram.Program.Framework.Presentation.Common;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.Framework.Presentation.GetRaffleEntries
{
    class GetRaffleEntriesViewModel : IViewModel
    {

        public List<RaffleEntryViewModel> RaffleEntries { get; set; }

        public string Errors { get; set; }
    }
}
