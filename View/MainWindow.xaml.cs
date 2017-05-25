using Mathematics;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool OptionPanelIsVisible = false;
        public bool isRandomlyPlacement = true;
        public MainWindow()
        {
		
           InitializeComponent();
            // WARNING: THIS CODE VIOLATES MVVM PRINCIPLES
            // IT IS FOR ILLUSTRATIVE PURPOSES ONLY
        /*
            this.Simulation = new Simulation();
            this.Simulation.Species[0].CreateBoid(new Vector2D(50, 50));
            this.Simulation.Species[1].CreateBoid(new Vector2D(150, 150));
            this.Simulation.Species[2].CreateBoid(new Vector2D(200, 200));
            this.DataContext = this;
             //Using the timer like this will yield choppy animation
             var timer = new DispatcherTimer(TimeSpan.FromMilliseconds(20), DispatcherPriority.Render, (x, y) => { this.Simulation.Update(0.02); }, this.Dispatcher);
             timer.Start();
            */
        }

        private void ChangeWindowState(object sender, RoutedEventArgs e)
        {
            if (OptionPanelIsVisible)
            {
                LeftOptionsPanel.Visibility = Visibility.Collapsed;
                RightOptionsPanel.Visibility = Visibility.Collapsed;
                OptionPanelIsVisible = false;
            }
            else
            {
                LeftOptionsPanel.Visibility = Visibility.Visible;
                RightOptionsPanel.Visibility = Visibility.Visible;
                OptionPanelIsVisible = true;
            }
        }

        private void ChangePlacement(object sender, RoutedEventArgs e)
        {
            if (isRandomlyPlacement)
            {
                PlacementButton.Content = "RandomPlace";
                isRandomlyPlacement = false;
            }
            else
            {
                PlacementButton.Content = "StaticPlace";
                isRandomlyPlacement = true;
            }
        }

        private void RandomColor(object sender, RoutedEventArgs e)
        {
            double b = r.Next(0, 255);
            byte b1 = Convert.ToByte(b);
            b = r.Next(0, 255);
            byte b2 = Convert.ToByte(b);
            b = r.Next(0, 255);
            byte b3 = Convert.ToByte(b);
            SolidColorBrush a = new SolidColorBrush(Color.FromRgb(b1,b2,b3));
            LeftOptionsPanel.Background = a;
            RightOptionsPanel.Background = a;
        }
        private Random r = new Random();

        /*
public Simulation Simulation { get; }
*/
    }
}
