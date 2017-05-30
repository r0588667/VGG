using System;
using System.Windows;
using System.Windows.Media;

namespace View
{
    public partial class MainWindow : Window
    {
        public bool OptionPanelIsVisible = false;
        public bool isRandomlyPlacement = true;
        private Random r = new Random();
        public MainWindow()
        {
		
           InitializeComponent();
        }

        private void ChangeWindowState(object sender, RoutedEventArgs e)
        {
            Visibility v = OptionPanelIsVisible ? Visibility.Collapsed : Visibility.Visible;
            OptionPanelIsVisible = OptionPanelIsVisible ? false : true;
            LeftOptionsPanel.Visibility = v;
            RightOptionsPanel.Visibility = v;
        }

        private void ChangePlacement(object sender, RoutedEventArgs e)
        {
            String PlacementString = isRandomlyPlacement ? "RandomPlace" : "StaticPlace";
            isRandomlyPlacement = isRandomlyPlacement ? false : true;
            PlacementButton.Content = PlacementString;
        }

        private void RandomColor(object sender, RoutedEventArgs e)
        {
            double b = r.Next(0, 255);
            byte b1 = Convert.ToByte(b);
            b = r.Next(0, 255);
            byte b2 = Convert.ToByte(b);
            b = r.Next(0, 255);
            byte b3 = Convert.ToByte(b);
            SolidColorBrush color = new SolidColorBrush(Color.FromRgb(b1,b2,b3));
            RightOptionsPanel.Background = color;
        }

    }
}
