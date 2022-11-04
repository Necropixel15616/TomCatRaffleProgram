using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TomCatRaffleProgram.Program
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            this.CreateFileOnStartup();
            Window mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void CreateFileOnStartup()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filePath = Path.Combine(folder, @"TomCatRaffle\");
            Directory.CreateDirectory(filePath);

            FileInfo file = new FileInfo($"{filePath}RaffleData.xml");
            if (!file.Exists)
            {
                using(var sw = file.CreateText())
                {
                    sw.WriteLine("<Raffles></Raffles>");
                    sw.Close();
                }
            }

        }
    }
}
