using System;
using System.IO.Ports;
using System.Windows;
using System.Windows.Controls;
using UniconGS.Source;

namespace UniconGS
{
    /// <summary>
    ///     Interaction logic for CreateConnectionWizard.xaml
    /// </summary>
    public partial class CreateConnectionWizard : Window
    {
        public CreateConnectionWizard()
        {
            InitializeComponent();
            ResultDialog = new Result();
            uiConnectionCancel.Click += uiConnectionCancel_Click;
            uiSettingsCancel.Click += uiConnectionCancel_Click;
            uiNext.Click += uiNext_Click;
            uiRelodePorts.Click += uiRelodePorts_Click;
            uiBack.Click += uiBack_Click;
            uiApply.Click += uiApply_Click;
        }

        public Result ResultDialog { get; set; }
        public static int DeviceConnected = 0;
        private void uiApply_Click(object sender, RoutedEventArgs e)
        {
            if (uiSpeed.SelectedIndex == -1)
                MessageBox.Show("Не выбрана скорость порта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                try
                {
                    if (!Validator.ValidateTextBox(uiDeviceNumber, 1, 255))
                    {
                        MessageBox.Show("Не верно задан намер устройства", "Ошибка", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                    else
                    {
                        if (!Validator.ValidateTextBox(uiTimeout, 1, 10000))
                        {
                            MessageBox.Show("Не верно задано время ожидания", "Ошибка", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                        }
                        else
                        {
                            //  this.ResultDialog.KNNumber = int.Parse(this.uiKNNumber.Text);
                            DeviceConnected = 1;
                            ResultDialog.DeviceNumber = int.Parse(uiDeviceNumber.Text);
                            ResultDialog.PortSpeed =
                                int.Parse((uiSpeed.SelectedItem as ComboBoxItem).Content.ToString());
                            ResultDialog.Timeout = int.Parse(uiTimeout.Text);
                            DialogResult = true;
                            Close();
                        }
                    }
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Введено не верное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
        }

        private void uiBack_Click(object sender, RoutedEventArgs e)
        {
            ResultDialog.DeviceNumber = -1;
            ResultDialog.KNNumber = -1;
            ResultDialog.PortSpeed = 0;
            ResultDialog.Timeout = -1;
            ResultDialog.PortName = string.Empty;
            uiMainDialog.SelectedItem = uiConnection;
            uiConnection.IsEnabled = true;
            uiSettings.IsEnabled = false;
            uiRelodePorts_Click(this, new RoutedEventArgs());
        }

        private void uiRelodePorts_Click(object sender, RoutedEventArgs e)
        {
            uiPorts.Items.Clear();
            foreach (var item in SerialPort.GetPortNames())
            {
                var it = new ComboBoxItem();
                it.Content = item;
                uiPorts.Items.Add(it);
            }
            if (uiPorts.Items.Count != 0)
                uiPorts.SelectedIndex = 0;
            else
                MessageBox.Show("На данном компьютере не обнаружено COM-портов.", "Внимание", MessageBoxButton.OK,
                    MessageBoxImage.Information);
        }

        private void uiNext_Click(object sender, RoutedEventArgs e)
        {
            if (uiPorts.SelectedIndex != -1)
            {
                var comboBoxItem = uiPorts.SelectedItem as ComboBoxItem;
                if (comboBoxItem != null)
                    ResultDialog.PortName = comboBoxItem.Content.ToString();
                uiSettings.IsEnabled = true;
                uiMainDialog.SelectedItem = uiSettings;
                uiConnection.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Не выбран порт.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void uiConnectionCancel_Click(object sender, RoutedEventArgs e)
        {
            ResultDialog = null;
            DialogResult = false;
            Close();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in SerialPort.GetPortNames())
            {
                var it = new ComboBoxItem();
                it.Content = item;
                uiPorts.Items.Add(it);
            }
            if (uiPorts.Items.Count != 0)
                uiPorts.SelectedIndex = 0;
            else
                MessageBox.Show("На данном компьютере не обнаружено COM-портов.", "Внимание", MessageBoxButton.OK,
                    MessageBoxImage.Information);
        }

        public class Result
        {
            public Result(string portName, int knNumber, int deviceNumber, int portSpeed, int timeout)
            {
                KNNumber = knNumber;
                DeviceNumber = deviceNumber;
                PortName = portName;
                PortSpeed = portSpeed;
                Timeout = timeout;
            }

            public Result()
            {
                KNNumber = -1;
                DeviceNumber = -1;
                PortName = string.Empty;
                PortSpeed = 0;
                Timeout = -1;
            }

            public string PortName { get; set; }
            public int DeviceNumber { get; set; }
            public int PortSpeed { get; set; }
            public int Timeout { get; set; }
            public int KNNumber { get; set; }
        }
    }
}