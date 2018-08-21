﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Windows.Threading;
using UniconGS.UI;
using UniconGS.Source;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using UniconGS.Annotations;
using UniconGS.Interfaces;
using UniconGS.UI.Configuration;
using UniconGS.UI.GPRS;
using UniconGS.UI.HeatingSchedule;
using UniconGS.UI.Journal;
using UniconGS.UI.Schedule;
using UniconGS.UI.Settings;
using UniconGS.UI.Time;
using TabControl = System.Windows.Controls.TabControl;

namespace UniconGS.UI.DiscretModules
{
    /// <summary>
    /// Interaction logic for AllStates.xaml
    /// </summary>
    public partial class AllStates : UserControl, IUpdatableControl 
    {
        #region Globals
       private ushort[] _value;
       private delegate void ReadComplete(ushort[] res);
        #endregion

        public AllStates()
        {
            InitializeComponent();
            if (DeviceSelection.SelectedDevice == 1)
            {
                uiGroupBox3.Visibility = Visibility.Hidden;
                uiGroupBox4.Visibility = Visibility.Hidden;
                uiGroupBox2.Visibility = Visibility.Hidden;
                
            }
            else if (DeviceSelection.SelectedDevice == 2)
            {
                uiGroupBox3.Visibility = Visibility.Visible;
                uiGroupBox4.Visibility = Visibility.Visible;
                uiGroupBox2.Visibility = Visibility.Visible;
            }
            else if (DeviceSelection.SelectedDevice == 3)
            {
                //uiGroupBox3.Visibility = Visibility.Visible;
                //uiGroupBox4.Visibility = Visibility.Visible;
                //uiGroupBox2.Visibility = Visibility.Visible;
            }
        }

      
     

        #region Privtaes
        private void SetDefault()
        {
            this.uiState1.Value = null;
            this.uiState2.Value = null;
            this.uiState3.Value = null;
            this.uiState4.Value = null;
        }

        private void SetStates(ushort[] value)
        {
            /*Т.к. дискретных модулей 4*/
            this.uiState1.Value = new ushort[] {value[0], value[1]};
            this.uiState2.Value = new ushort[] { value[2], value[3] };
            this.uiState3.Value = new ushort[] { value[4], value[5] };
            this.uiState4.Value = new ushort[] { value[6], value[7] };
        }
        #endregion

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
                    this.SetDefault();
                }
                else
                {
                    this._value = value;
                    this.SetStates(value);
                }
                
            }
        }

        public async Task Update()
        {

            ushort[] value = await RTUConnectionGlobal.GetDataByAddress(1, 0x0005, 8);
            Application.Current.Dispatcher.Invoke(() =>
            {
                SetStates(value);
            });
        }

        private void ReadCompleted(ushort[] res)
        {
            this.Value = res;
        }

        public bool WriteContext()
        {
            throw new NotImplementedException();
        }
        #endregion

    }


}