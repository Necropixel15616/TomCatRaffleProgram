using System;
using System.Windows;
using TomCatRaffleProgram.Program.Framework.Views;

namespace TomCatRaffleProgram.Program
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            mainWindowFrame.Navigate(serviceProvider.GetService(typeof(MainPage)));
        }
    }
}
