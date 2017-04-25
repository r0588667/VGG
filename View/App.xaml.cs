using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;
using ViewModel.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Mathematics;
using Model;
using View.Timer;
using System.Windows.Threading;

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
            /*
            var timer = ServiceLocator.Current.GetInstance<ITimerService>();
            timer.Tick += Timer_Tick;
            timer.Start(new TimeSpan(0, 0, 0,0,100));
            */
			var mainWindow = new MainWindow();
            MainViewModel mvm = new MainViewModel();
            mainWindow.DataContext = mvm;
           mvm.evm.ApplicationExit += ExitViewModel_ApplicationExit;
            mainWindow.Show();
        }
        private void ExitViewModel_ApplicationExit()
        {
            Application.Current.Shutdown();
        }
	}
}
