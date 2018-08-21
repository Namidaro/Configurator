﻿using System;
using System.Collections;
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
using UniconGS.Interfaces;
using UniconGS.Source;

namespace UniconGS.UI
{
    /// <summary>
    /// Логика взаимодействия для FuseErrors.xaml
    /// </summary>
    public partial class FuseErrors : UserControl, IUpdatableControl
    {
        public FuseErrors()
        {
            InitializeComponent();
        }

        #region Globals
        private ushort[] _value;


        private delegate void ReadComplete(ushort[] res);
        #endregion


        private void DisableAllFlags()
        {
            foreach (var item in this.uiFuseErrors.Children)
            {
                (item as BitViewer).Value = null;
            }
           
        }

        private void SetAllFlags(ushort value)
        {
            BitArray array = Converter.GetBitsFromWord(value);

            for (int i = 0; i < this.uiFuseErrors.Children.Count; i++)
            {
                (this.uiFuseErrors.Children[i] as BitViewer).Value = array[i];
            }
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
                    this.DisableAllFlags();
                }
                else
                {
                    this.SetAllFlags(value[0]);
                }
            }
        }
    
        public async Task Update()
        {


            ushort[] value = await RTUConnectionGlobal.GetDataByAddress(1, 0x0303, 1);
            Application.Current.Dispatcher.Invoke(() =>
            {
                SetAllFlags(value[0]);
            });
           
        }
        #endregion



    }


}
