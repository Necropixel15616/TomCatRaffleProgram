using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TomCatRaffleProgram.Program.Framework.Presentation.CommonViewModels;

namespace TomCatRaffleProgram.Program.Framework.Presentation
{
    interface IOutputPortPresenter<TEntity>
    {
        public Task<TEntity> Result { get; set; }

        public bool PresentedSuccessfully { get; set; }
    }
}
