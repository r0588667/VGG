using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            //var container = new UnityContainer();
            //container.RegisterInstance<IUnityContainer>(container);
         //   container.RegisterInstance<IMessageBoxService>(new MessageBoxService());
            //UnityServiceLocator locator = new UnityServiceLocator(container);
            //ServiceLocator.SetLocatorProvider(() => locator);

            var mainWindow = new MainWindow();
            var exitViewModel = new ExitViewModel();
            exitViewModel.ApplicationExit += ExitViewModel_ApplicationExit;
            mainWindow.DataContext = exitViewModel;
            mainWindow.Show();
        }
        private void ExitViewModel_ApplicationExit()
        {
            Application.Current.Shutdown();
        }
    }
}
