using System.Windows;
using MagicznyMiecz.GUI.ViewModels;

namespace MagicznyMiecz.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var shellViewModel = new ShellViewModel();
            var shell = new Shell { DataContext = shellViewModel };
            shell.Show();
        }
    }
}
