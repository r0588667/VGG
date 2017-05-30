using System.Windows;
using ViewModel;
using ViewModel.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using View.Timer;

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
			var container = new UnityContainer();
			container.RegisterInstance<IUnityContainer>(container);
            container.RegisterType<ITimerService, TimerService>();
			UnityServiceLocator locator = new UnityServiceLocator(container);
			ServiceLocator.SetLocatorProvider(() => locator);
			var mainWindow = new MainWindow();
            MainViewModel mvm = new MainViewModel();
            mainWindow.DataContext = mvm;
            mvm.ApplicationExit += ApplicationExit;
            mainWindow.Show();
        }
        private void ApplicationExit()
        {
            Application.Current.Shutdown();
        }
	}
}
