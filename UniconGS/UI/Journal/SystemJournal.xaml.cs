using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using UniconGS.Interfaces;
using UniconGS.Source;
using UniconGS.Enums;

namespace UniconGS.UI.Journal
{
    /// <summary>
    /// Interaction logic for SystemJournal.xaml
    /// </summary>
    public partial class SystemJournal : UserControl, IUpdatableControl
    {
        #region Events
        public delegate void ShowMessageEventHandler(string message, string caption, MessageBoxImage image);
        public event ShowMessageEventHandler ShowMessage;

        public delegate void StartWorkEventHandler();
        public delegate void StopWorkEventHandler();

        private delegate void ReadComplete(ushort[] res);
        #endregion

        #region [CONST]
        private const ushort PICON2_JOURNAL_RECORD_COUNT_ADDRESS = 0x6000;
        //private const ushort PICON2_JOURNAL_
        private const ushort PICON2_JOURNAL_STRING_SIZE = 0x0;//?????????????????????? 

        #endregion


        #region Globals
        private ObservableCollection<EventJournalItem> _eventJournal = new ObservableCollection<EventJournalItem>();

        #endregion

        public void SetAutonomous()
        {
            this.uiImport.IsEnabled = false;
        }

        public void DisableAutonomous()
        {
            this.uiImport.IsEnabled = true;
        }

        public ObservableCollection<EventJournalItem> EventJournal
        {
            get
            {
                return this._eventJournal;
            }
            set
            {
                this._eventJournal = value;
            }
        }

        public SystemJournal()
        {
            InitializeComponent();
            //if (DeviceSelection.SelectedDevice == (int)DeviceSelectionEnum.DEVICE_PICON2)
            //{
            //    uiImport.IsEnabled = false;

            //}

            //else
            //{
            //    uiImport.IsEnabled = true;

            //}
        }

        private void uiImport_Click(object sender, RoutedEventArgs e)
        {
            ImportJournal();
        }

        private async void ImportJournal()
        {
            if (DeviceSelection.SelectedDevice != (int)DeviceSelectionEnum.DEVICE_PICON2)
            {
                try
                {
                    uiImport.IsEnabled = false;
                    var valFromDevice = await ReadJournalValue();
                    SetJournalValue(valFromDevice);
                }



                //var result = RTUConnectionGlobal.ModbusMaster.ReadInputRegistersAsync(1, 0x2001, 3910);
                catch (SystemException ex)
                {

                }
                finally
                {
                    uiImport.IsEnabled = true;
                }
            }
            else
            {

                var valFromDevice = await ReadJournalValue();
                SetJournalValue(valFromDevice);
                //ShowMessage("Функция не реализована!", "Внимание", MessageBoxImage.Information);
            }
        }

        #region Privtaes

        public async Task<ushort[]> ReadJournalValue()
        {
            //if (this.uiJournal != null)
            //{
            //var result = RTUConnectionGlobal.ModbusMaster.ReadInputRegistersAsync(1, 0x2001, 3910);
            //if (result != null)
            //{

            //}
            //else if (this.ShowMessage != null)
            //{
            //    this.ShowMessage("Во время чтения журнала системы произошла ошибка", "Чтение журнала системы",
            //        MessageBoxImage.Error);
            //}
            //}
            //this.Dispatcher.BeginInvoke(new Action(() => uiImport.IsEnabled = true));
            if (DeviceSelection.SelectedDevice == (int)DeviceSelectionEnum.DEVICE_PICON2)
            {

                //видимо надо как-то чекать версию процессора и там будут разные адреса на журнал
                // но это уже завтра
                ushort[] Picon2JournalReportCountUshort = new ushort[1];
                Picon2JournalReportCountUshort = await RTUConnectionGlobal.GetDataByAddress(1, (ushort)0x4000, 1);
                byte Picon2JournalReportCountLOByte = LOBYTE(Picon2JournalReportCountUshort[0]);
                byte Picon2JournalReportCountHIByte = HIBYTE(Picon2JournalReportCountUshort[0]);

                //
                List<ushort> ushorts = new List<ushort>();
                for (ushort i = 0; i < 640; i++)
                {
                    ushorts.AddRange(await RTUConnectionGlobal.GetDataByAddress(1, (ushort)(0x6000 + i), 1));
                }
                ushorts.AddRange(await RTUConnectionGlobal.GetDataByAddress(1, (ushort)(0x4100), 1));
                return ushorts.ToArray();
            }
            else
            {


                List<ushort> ushorts = new List<ushort>();
                for (ushort i = 0; i < 3900; i += 100)
                {
                    ushorts.AddRange(await RTUConnectionGlobal.GetDataByAddress(1, (ushort)(0x2001 + i), 100));
                }
                ushorts.AddRange(await RTUConnectionGlobal.GetDataByAddress(1, 0x2001 + 3900, 10));

                return ushorts.ToArray();
            }
            //}
        }

        private void SetJournalValue(ushort[] value)
        {
            try
            {
                this.EventJournal.Clear();
                var longMessage = Converter.GetStringWithNullsFromWords(value).ToCharArray().ToList();
                /*Разделить строку на подстроки и составить список*/
                List<EventJournalItem> tmp = new List<EventJournalItem>();
                //var str = string.Empty;
                for (int i = 0; i < 170; i++)
                {
                    tmp.Add(new EventJournalItem(new String(longMessage.GetRange(i * 46, 46).ToArray())));
                }
                tmp.Sort(delegate (EventJournalItem first, EventJournalItem second)
                {
                    if ((double)first.JournalDateTime.Ticks / TimeSpan.TicksPerSecond >
                        (double)second.JournalDateTime.Ticks / TimeSpan.TicksPerSecond)
                        return -1;
                    if ((double)first.JournalDateTime.Ticks / TimeSpan.TicksPerSecond <
                        (double)second.JournalDateTime.Ticks / TimeSpan.TicksPerSecond)
                        return 1;
                    else
                        return 0;
                });
                foreach (var item in tmp)
                {
                    this.EventJournal.Add(item);
                }
                if (this.ShowMessage != null)
                {
                    if (EventJournal.Count != 0)
                    {
                        this.ShowMessage("Чтение журнала системы прошло успешно", "Чтение журнала системы",
                            MessageBoxImage.Information);
                    }
                    else
                    {
                        this.ShowMessage("Журнал системы пуст.", "Чтение журнала системы", MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception e)
            {
                if (this.ShowMessage != null)
                {
                    this.ShowMessage("Во время чтения журнала системы произошла ошибка", "Чтение журнала системы",
                        MessageBoxImage.Error);
                }
            }
        }
        #endregion

        /// <summary>
        /// Возвращает младший байт слова
        /// </summary>
        /// <param name="v">Слово.</param>
        /// <returns>Мл.байт</returns>
        public static byte LOBYTE(int v)
        {
            return (byte)(v & 0xff);
        }
        /// <summary>
        /// Возвращает старший байт слова.
        /// </summary>
        /// <param name="v">Слово.</param>
        /// <returns>Ст.байт</returns>
        public static byte HIBYTE(int v)
        {
            return (byte)(v >> 8);
        }

        public ushort[] Value { get; set; }

        public async Task Update()
        {
            if (DeviceSelection.SelectedDevice == (int)DeviceSelectionEnum.DEVICE_PICON2)
            {
                try
                {
                    //ushort[] value = await RTUConnectionGlobal.GetDataByAddress(1, 0x6000, 2);
                    //Application.Current.Dispatcher.Invoke(() =>
                    //{
                    //    SetJournalValue(value);

                    //});

                    //this.ReadJournalValue();
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, "Error", MessageBoxImage.Error);
                }
            }
            else
            {
                try
                {
                    ushort[] value = await RTUConnectionGlobal.GetDataByAddress(1, 0x2001, 3910);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        SetJournalValue(value);

                    });

                    this.ReadJournalValue();
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, "Error", MessageBoxImage.Error);
                }
            }
            //if (this.StopWork != null)
            //{
            //    this.Dispatcher.BeginInvoke(DispatcherPriority.SystemIdle, new Action(() =>
            //    {
            //        StopWork();
            //        StateTextBlock.Text = string.Empty;
            //    }));
            //}

            

        }

    }

}

