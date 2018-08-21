﻿using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UniconGS.Interfaces;
using UniconGS.Source;
using System.Threading.Tasks;

namespace UniconGS.UI
{
    /// <summary>
    /// Interaction logic for KUErrors.xaml
    /// </summary>
    public partial class KUErrors : UserControl, IUpdatableControl
    {
        #region Globals
        private ushort[] _value;
        private Slot _query;

        private delegate void ReadComplete(ushort[] res);
        #endregion

        public KUErrors()
        {
            InitializeComponent();
        }

        private void SetDefault()
        {
            this.uiErrors.Children.OfType<BitViewer>().ToList().ForEach((alarm) => { alarm.Value = null; });
        }

        private void SetErrors(ushort[] value)
        {
            var tmp = Converter.GetBitsFromWord(value[0]).OfType<bool>().ToList();
            for (int i = 0; i < 5; i++)
            {
                (this.uiErrors.Children[i] as BitViewer).Value = tmp[i];
            }
        }

        void RunWorkerComplete(ushort[] value)
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
                    this.SetDefault();
                }
                else
                {
                    SetErrors(value);
                }
            }
        }
        //public Slot Querer
        //{
        //    get
        //    {
        //        return this._query;
        //    }
        //    set
        //    {
        //        this._query = value;
        //    }
        //}
        public async Task Update()
        {
            ushort[] value = await RTUConnectionGlobal.GetDataByAddress(1, 0x0004, 1);
            //var res = DataTransfer.ReadWords(this._query);new Slot(0x0004, 1, "Errors");
            //this.Dispatcher.BeginInvoke(new ReadComplete(RunWorkerCompleted), DispatcherPriority.SystemIdle,res);
            Application.Current.Dispatcher.Invoke(() =>
            {
                SetErrors(value);
            });
        }
        //public bool WriteContext()
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }
}