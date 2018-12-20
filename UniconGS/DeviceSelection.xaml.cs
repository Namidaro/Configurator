using System;
using System.IO.Ports;
using System.Windows;
using UniconGS.Source;

namespace UniconGS
{
    /// <summary>
    ///     Interaction logic for DeviceSelection.xaml
    /// </summary>
    public partial class DeviceSelection : Window
    {
        public static int SelectedDevice;

        public DeviceSelection()
        {
            InitializeComponent();
            uiRunoSelection.Click += uiRunoSelection_Click;
            uiPiconGSSelection.Click += uiPiconGSSelection_Click;
            uiPicon2Selection.Click += uiPicon2Selection_Click;
            //uiLuxometr.Click += uiLuxometr_Click;
        }

        private void uiRunoSelection_Click(object sender, RoutedEventArgs e)
        {
          
            DeviceSelection.SelectedDevice = 1;
            var mainWindow = new MainWindow
            {
                Title = "БЭМН Конфигуратор Минск ГОРСВЕТ - РУНО 3"
            };
            this.Hide();
            
            mainWindow.Show();
            mainWindow.Closed += this.ChildWindowClosed;
        }

        private void uiPiconGSSelection_Click(object sender, RoutedEventArgs e)
        {
           
            DeviceSelection.SelectedDevice = 2;
            var mainWindow = new MainWindow
            {
                Title = "БЭМН Конфигуратор Минск ГОРСВЕТ - ПИКОН ГС 2"
            };
            this.Hide();
           
            mainWindow.Show();
            mainWindow.Closed += this.ChildWindowClosed;
        }

        
        //private void uiLuxometr_Click(object sender, RoutedEventArgs e)
        //{
        //    DeviceSelection.SelectedDevice = 3;
        //    var luxmetr = new Luxmetr
        //    {
        //        Title = "БЭМН Конфигуратор Минск ГОРСВЕТ - Люксометр"
        //    };
        //    this.Hide();

        //    luxmetr.Show();
        //    luxmetr.Closed += this.ChildWindowClosed;

        //}
        

        private void ChildWindowClosed(object sender, EventArgs e)
        {
            RTUConnectionGlobal.CloseConnection();
            this.Show();
        }

        private void uiPicon2Selection_Click(object sender, RoutedEventArgs e)
        {
            DeviceSelection.SelectedDevice = 3;
            var mainWindow = new MainWindow
            {
                Title = "БЭМН Конфигуратор Минск ГОРСВЕТ - ПИКОН2"
            };
            this.Hide();

            mainWindow.Show();
            mainWindow.Closed += this.ChildWindowClosed;
        }
    }
}