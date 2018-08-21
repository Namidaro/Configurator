using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using UniconGS.Interfaces;
using UniconGS.Source;

namespace UniconGS.UI
{
    /// <summary>
    /// Interaction logic for Meter.xaml
    /// </summary>
    public partial class Meter : UserControl, IUpdatableControl 
    {
        #region Globals
        private ushort[] _value;
        public delegate void StartWorkEventHandler();
        public delegate void StopWorkEventHandler();
       public delegate void ShowMessageEventHandler(string message, string caption, MessageBoxImage image);
       #endregion

        public Meter()
        {
            InitializeComponent();
        }

        
      private void DisableAll()
        {
            foreach (var item in this.PART_DATAHOLDER.Children)
            {
                if (item is Label)
                {
                    (item as Label).Content = "Нет значения";
                }
            }
        }
      
        private void SetAll(Label lable, ushort[] value, int sourceIndex)
        {
            //var valFromMeter = await ReadAll();
            //SetAll(valFromMeter);
            ushort[] tmp = new ushort[16];
            

            if (value[0] == 0)
            {
                lable.Content = "Нет значения";
            }
            else
            {
                Array.Copy(value, sourceIndex, tmp, 0, 8);
                lable.Content = Converter.GetStringFromWords(tmp);
            }
        }
        private void SetAll(ushort[] value)
        {
            this.SetAll(this.uiDate, value, 8);
            this.SetAll(this.uiTime, value, 16);
            this.SetAll(this.uiSerialNumber, value, 24);
            this.SetAll(this.uiPowerA, value, 40);
            this.SetAll(this.uiPowerB, value, 48);
            this.SetAll(this.uiPowerC, value, 56);
            this.SetAll(this.uiVoltageA, value, 64);
            this.SetAll(this.uiVoltageB, value, 72);
            this.SetAll(this.uiVoltageC, value, 80);
            this.SetAll(this.uiCurrentA, value, 88);
            this.SetAll(this.uiCurrentB, value, 96);
            this.SetAll(this.uiCurrentC, value, 104);
            this.SetAll(this.uiEnergyO, value, 120);
            this.SetAll(this.uiEnergyM, value, 128);
            this.SetAll(this.uiEnergyD, value, 136);
        }

        void ReadCompleted(ushort[] value)
        {
            this.Value = value;
        }

        #region IQueryMember
        public ushort[] Value
        {
            get
            {
                return this._value;
            }
            set
            {
                if (value == null)
                {
                    this.DisableAll();
                }
                else
                {
                    this.SetAll(value);
                    this._value = value;
                }

            }
        }
  
        public async Task Update()
        {
            {
                ushort[] value = await ReadAll();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    SetAll(value);
                });
            }
           
    }

        private async Task<ushort[]> ReadAll()
        {
            List<ushort> ushorts = new List<ushort>();
            for (ushort i = 0; i < 200; i += 100)
            {
                ushorts.AddRange(await RTUConnectionGlobal.GetDataByAddress(1, (ushort)(0x0208 + i), 100));
            }
            ushorts.AddRange(await RTUConnectionGlobal.GetDataByAddress(1, 0x0208 + 200, 86));

            return ushorts.ToArray();
        }

        #endregion
    }
}
