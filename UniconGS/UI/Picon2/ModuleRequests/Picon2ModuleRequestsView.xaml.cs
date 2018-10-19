using System;
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
using UniconGS.Enums;

namespace UniconGS.UI.Picon2.ModuleRequests
{
    /// <summary>
    /// Логика взаимодействия для Picon2ModuleRequestsView.xaml
    /// </summary>
    public partial class Picon2ModuleRequestsView : UserControl
    {
        public Picon2ModuleRequestsView()
        {
            InitializeComponent();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //todo: переделать, надо как-то отследить изменение конкретного значения в коллекции
            var vm = this.DataContext as Picon2ModuleRequestsViewModel;
            for (byte i = 0; i < vm.ModuleListForUI.Count; i++)
            {
                vm.ImageSRCList[i] = vm.GetImageSRC(vm.GetModuleType(vm.ModuleListForUI[i]));
            }
        }
    }
}
