using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using NModbus4.Device;
using UniconGS.Interfaces;
using UniconGS.Source;
using UniconGS.UI.Configuration;
using UniconGS.UI.GPRS;
using Table = UniconGS.UI.Schedule.Schedule;
using HeatingTable = UniconGS.UI.HeatingSchedule.HeatingSchedule;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;
using System.Windows.Controls.Primitives;
using UniconGS.UI.Schedule;

namespace UniconGS.UI.Settings
{
    /// <summary>
    /// Логика взаимодействия для ControllerSettings.xaml
    /// </summary>
    public partial class ControllerSettings
    {
        #region Fields

        public delegate void ShowMessageEventHandler(string message, string caption, MessageBoxImage image);

        public event ShowMessageEventHandler ShowMessage;


        private delegate void ReadCompleteDelegate(ushort[] res);

        private delegate void WriteCompleteDelegate(bool res);

        public delegate Settings GetControlsValueDelegate();

        public delegate void SetValueControlsDelegate(Settings settings);

        object x;
        public event GetControlsValueDelegate GetControlsValue;
        public event SetValueControlsDelegate SetControlsValue;

        private Settings _settings;

        private bool _isWriteSettings;
        //private ushort[] _logicConfig;
        //private ushort[] _lightingSchedule;
        //private ushort[] _backlightSchedule;
        //private ushort[] _illuminationSchedule;
        //private ushort[] _conservationEnergySchedule;
        //private ushort[] _heatingSchedule;
        //private ushort[] _gprsConfig;

        #endregion

        public bool IsAutonomous { get; set; }

        public Config Config { get; set; }

        public ControllerSettings()
        {
            InitializeComponent();
            if (DeviceSelection.SelectedDevice == 3)
            {
                uiPLCReset.IsEnabled = false;
                uiSignature.IsEnabled = false;
                uiWriteAll.IsEnabled = false;
                uiReadAll.IsEnabled = false;
            }

            else
            {
                uiPLCReset.IsEnabled = true;
                uiSignature.IsEnabled = true;
                uiWriteAll.IsEnabled = true;
                uiReadAll.IsEnabled = true;
            }
        }

        public event EventHandler ReadAll;

        public event EventHandler WriteAll;
        //public void SetData(ushort[] s1, ushort[] s2, ushort[] s3, ushort[] s4, ushort[] s5, ushort[] s6, ushort[] s7)
        //{
        //    _lightingSchedule = s1;
        //    _backlightSchedule = s2;
        //    _illuminationSchedule = s3;
        //    _logicConfig = s4;
        //    _conservationEnergySchedule = s5;
        //    _heatingSchedule = s6;
        //    _gprsConfig = s7;

        //}

        #region Signature

        private async void uiSignature_Click(object sender, RoutedEventArgs e)
        {
            uiSignature.IsEnabled = false;
            try
            {
                ushort[] res = await RTUConnectionGlobal.GetDataByAddress(1, (ushort) (0x0400), 52);
                ReadSignatureComplete(res);
            }
            catch (Exception exception)
            {

            }
            uiSignature.IsEnabled = true;
        }

        private string GetSignatureString(List<ushort> value)
        {
            ushort[] deviceName = value.GetRange(0, 4).ToArray();
            ushort[] version = value.GetRange(8, 3).ToArray();
            ushort[] date = value.GetRange(16, 5).ToArray();

            var devName = "Имя устройства: " + Converter.GetStringFromWords(deviceName) + ";\r\n";
            var v = "Версия:  " + ((byte) (version[1] >> 8)).ToString() + "."
                    + ((byte) version[1]).ToString() + "."
                    + ((byte) (version[0] >> 8)).ToString() + "."
                    + ((byte) version[0]).ToString() + ";\n\r";
            var d = "Дата: " + Converter.GetStringFromWords(date) + ".";

            return devName + v + d;
        }

        private void ReadSignatureComplete(ushort[] value)
        {
            if (value == null)
            {
                ShowMessage("Ошибка чтения сигнауры", "Сигнатура устройства.", MessageBoxImage.Error);
            }
            else
            {
                ShowMessage(this.GetSignatureString((value).ToList()), "Сигнатура устройства.",
                    MessageBoxImage.Information);
            }
            uiSignature.IsEnabled = true;
        }

        #endregion Signature

        #region PLC reset

        private async void uiPLCReset_Click(object sender, RoutedEventArgs e)
        {
            uiPLCReset.IsEnabled = false;
            try
            {
                await RTUConnectionGlobal.SendDataByAddressAsync(1, (ushort) (0x0302),
                    new ushort[] {1});
                ShowMessage("Устройство было успешно сброшен.", "Внимание", MessageBoxImage.Information);
            }
            catch (Exception exception)
            {
                ShowMessage("Во время сброса устройства произошла ошибка.", "Ошибка", MessageBoxImage.Error);
            }
            uiPLCReset.IsEnabled = true;
        }

        #endregion

        #region Settings

        //private async void ApplySettings()
        //{
        //    if (!this.IsAutonomous)
        //    {
        //        if (this._settings == null)
        //        {
        //            ShowMessage("Настройки не импортированы", "Ошибка импорта настроек", MessageBoxImage.Error);
        //        }
        //        else
        //        {
        //        WriteSettings();
        //        }
        //    }
        //    else
        //    {
        //        ShowMessage("Невозможно записать настройки в устройство в автономном режиме.", "Автономный режим",
        //            MessageBoxImage.Exclamation);
        //    }
        //}

        private void uiSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
            sfd.InitialDirectory = this.Config.AllSettingsExportInitialFilePath;
            sfd.Filter = "Файл настройки Руно|*.gsset";
            sfd.Title = "Сохранение настроек \"Руно\"";
            sfd.FileName = "Настройки1";
            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (this.GetAllSettings().Save(sfd.FileName))
            {
                this.Config.AllSettingsExportInitialFilePath = sfd.FileName;
                ShowMessage("Файл сохранен успешно", "Сохранение настроек", MessageBoxImage.Information);
            }
            else
            {
                ShowMessage("Во время сохранения файла произошла ошибка", "Ошибка сохранения настроек",
                    MessageBoxImage.Error);
            }
            uiSaveSettings.IsEnabled = true;
        }

        private void uiOpenSettings_Click(object sender, RoutedEventArgs e)
        {

            var ofd = new System.Windows.Forms.OpenFileDialog
            {
                Filter = "Файл настройки Руно|*.gsset",
                Title = "Открытие файла настройки \"Руно\"",
                InitialDirectory = this.Config.AllSettingsImportInitialFilePath
            };
            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (System.IO.File.Exists(ofd.FileName))
            {
                if (this.SetAllSettings(Settings.Open(ofd.FileName)))
                {
                    this.Config.AllSettingsImportInitialFilePath = ofd.FileName;
                    SetControlsValue(_settings);
                    ShowMessage("Файл открыт успешно", "Открытие настроек", MessageBoxImage.Information);
                    //_isWriteSettings = true;
                    //this.ApplySettings();
                }
                else
                {
                    ShowMessage("Во время открытия файла произошла ошибка", "Ошибка открытия настроек",
                        MessageBoxImage.Error);
                }
            }
            else
            {
                ShowMessage("Выбранный файл не существует", "Ошибка открытия настроек", MessageBoxImage.Error);
            }

            uiOpenSettings.IsEnabled = true;
        }

        private Settings GetAllSettings()
        {
            //this.Dispatcher.Invoke(new Action(() => RefreshControls()));
            this._settings = this.GetControlsValue();

            return this._settings;
        }

        private bool SetAllSettings(Settings settings)
        {

            if (settings == null)
            {

                return false;
            }
            this._settings = settings;

            return true;
        }

        private async Task WriteSettings()
        {
            bool result = true;
            string message = string.Empty;

            try
            {




            }

            catch
            {
            }


            if (result)
                ShowMessage(@"Применение настроек прошло успешно." + "\r\n" + message, "Применение настроек",
                    MessageBoxImage.Information);
            else
                ShowMessage(@"Во время применения настроек произошла(и) ошибка(и)." + "\r\n" + message,
                    "Ошибка сохранения настроек", MessageBoxImage.Error);

        }


        #endregion Settings

        #region IQueryMember


        public ushort[] Value { get; set; }

        #endregion

        //private Table lightingSchedule;
        //private Table backlightSchedule;
        //private Table energySchedule;
        //private Table illuminationSchedule;


        private async void uiReadAll_Click(object sender, RoutedEventArgs e)
        {


            if (this.ReadAll != null)
            {
                this.ReadAll(this, new EventArgs());
            }

        }

        private async void uiWriteAll_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show(
                "Внимание! Проверьте графики и конфигурацию перед записью в устройство. Вы уверены, что хотите совершить запись графиков и конфигурации в устройство?",
                "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (res == MessageBoxResult.Yes)
            {
                if (this.WriteAll != null)
                {
                    this.WriteAll(this, new EventArgs());
                }
            }

            if (res == MessageBoxResult.No)
            {

            }
        }

        //public void Setup(Table uiLightingSchedule, Table uiBacklightSchedule, Table uiEnergySchedule, Table uiIlluminationSchedule)
        //{
        //    this.lightingSchedule = uiLightingSchedule;
        //    this.backlightSchedule = uiBacklightSchedule;
        //    this.energySchedule = uiEnergySchedule;
        //    this.illuminationSchedule = uiIlluminationSchedule;
        //}

        public void SetAutonomus()
        {
            this.uiPLCReset.IsEnabled = false;
            this.uiSignature.IsEnabled = false;
            this.uiReadAll.IsEnabled = false;
            this.uiWriteAll.IsEnabled = false;


        }
    }
}