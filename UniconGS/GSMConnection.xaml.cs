using System;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UniconGS.Source;


namespace UniconGS
{
    /// <summary>
    /// Логика взаимодействия для GSMConnection.xaml
    /// </summary>
    public partial class GSMConnection : Window
    {
        public const string r = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
        Regex reg = new Regex(r, RegexOptions.Compiled);

        public GSMConnection()
        {
            InitializeComponent();
            ResulGSM = new ResultGSM();
            uiApply.Click += uiApply_Click;
            uiSettingsCancel.Click += uiSettingsCancel_Click;
            uiiPTex.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(ip_PreviewTextImput);
            uiiPTex.PreviewKeyUp += UiiPTex_PreviewKeyUp;
           
            if (ConfiguratorSettings.Default.ipSettings == null)
            {
                uiiPTex.Text = "127.0.0.1";
            }
            else
            {
                uiiPTex.Text = ConfiguratorSettings.Default.ipSettings;
            }

        }

        private void UiiPTex_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            Check();
        }
        private void Check()
        {
            uiApply.IsEnabled = false;


            if (reg.IsMatch(uiiPTex.Text))
            {
                //e.Handled = true;
                uiApply.IsEnabled = true;
            }

            else
            {

            }
        }

        private void ip_PreviewTextImput(object sender, TextCompositionEventArgs e)
        {
            Check();
        }

        public ResultGSM ResulGSM { get; set; }



        private void uiApply_Click(object sender, RoutedEventArgs e)
        {

            ResultGSM.IPAdress = uiiPTex.Text;
            ResultGSM.PortNumber = int.Parse(uiPortNumberGSM.Text);
            ConfiguratorSettings.Default.ipSettings = uiiPTex.Text;
            ConfiguratorSettings.Default.Save();
            DialogResult = true;
            Close();


        }
        private void uiSettingsCancel_Click(object sender, RoutedEventArgs e)
        {
            ResultGSM.PortNumber = 0;
            ResultGSM.IPAdress = string.Empty;
            this.Close();
        }

        public class ResultGSM
        {
            public ResultGSM()

            {
                PortNumber = 0;
                IPAdress = String.Empty;

            }


            public static int PortNumber { get; set; }
            public static string IPAdress { get; set; }
        }


    }

}
