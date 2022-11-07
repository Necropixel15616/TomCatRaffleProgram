﻿using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.Framework.Presentation.Common
{
    class RaffleEntryViewModel : IViewModel
    {
        public string Errors { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Tickets { get; set; }
    }
}
