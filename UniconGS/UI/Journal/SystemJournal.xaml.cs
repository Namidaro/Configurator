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
            if (DeviceSelection.SelectedDevice == 3)
            {
                uiImport.IsEnabled = false;
               
            }

            else
            {
                uiImport.IsEnabled = true;
               
            }
        }

        private async void uiImport_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                uiImport.IsEnabled = false;
              var valFromDevice=  await ReadJournalValue();
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
            List<ushort> ushorts = new List<ushort>();
            for(ushort i = 0; i < 3900; i += 100)
            {
                ushorts.AddRange(await RTUConnectionGlobal.GetDataByAddress(1, (ushort)(0x2001+i), 100));
            }
            ushorts.AddRange(await RTUConnectionGlobal.GetDataByAddress(1, 0x2001 + 3900, 10));

            return ushorts.ToArray();
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
                tmp.Sort(delegate(EventJournalItem first, EventJournalItem second)
                {
                    if ((double) first.JournalDateTime.Ticks/TimeSpan.TicksPerSecond >
                        (double) second.JournalDateTime.Ticks/TimeSpan.TicksPerSecond)
                        return -1;
                    if ((double) first.JournalDateTime.Ticks/TimeSpan.TicksPerSecond <
                        (double) second.JournalDateTime.Ticks/TimeSpan.TicksPerSecond)
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


        public ushort[] Value { get ; set;}

        public async Task Update()
        {
            
            {
                ushort[] value = await RTUConnectionGlobal.GetDataByAddress(1, 0x2001, 3910);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    SetJournalValue(value);
                    
                });
            }  
            this.ReadJournalValue();
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
