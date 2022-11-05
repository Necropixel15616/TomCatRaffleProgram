using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TomCatRaffleProgram.Program.ApplicationLayer.Services
{
    class FileServices
    {
        private FileInfo File = new FileInfo(App.GetFilePath());

        public bool DoesFileExist()
            => File.Exists;
    }
}
