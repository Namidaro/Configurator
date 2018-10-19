using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniconGS.Enums;

namespace UniconGS.UI.Picon2.ModuleRequests.Resources
{
    public class ModuleTypeList
    {
        public SortedList<string, byte> ModuleList = new SortedList<string, byte>();

        public ModuleTypeList()
        {
            InitializeModuleList();
        }

        private void InitializeModuleList()
        {
            ModuleList.Add("Заглушка", (byte)(ModuleSelectionEnum.MODULE_EMPTY));
            ModuleList.Add("МРВ960", (byte)(ModuleSelectionEnum.MODULE_MRV960));
            ModuleList.Add("МРВ980", (byte)(ModuleSelectionEnum.MODULE_MRV980));
            ModuleList.Add("МС911", (byte)(ModuleSelectionEnum.MODULE_MS911));
            ModuleList.Add("МС911Р", (byte)(ModuleSelectionEnum.MODULE_MS911R));
            ModuleList.Add("МС915", (byte)(ModuleSelectionEnum.MODULE_MS915));
            ModuleList.Add("МС916", (byte)(ModuleSelectionEnum.MODULE_MS916));
            ModuleList.Add("МС917", (byte)(ModuleSelectionEnum.MODULE_MS917));
            ModuleList.Add("МСА961", (byte)(ModuleSelectionEnum.MODULE_MSA961));
            ModuleList.Add("МСА962", (byte)(ModuleSelectionEnum.MODULE_MSA962));
            ModuleList.Add("МСД980", (byte)(ModuleSelectionEnum.MODULE_MSD980));
            ModuleList.Add("МИИ901", (byte)(ModuleSelectionEnum.MODULE_MII901));
        }
    }
}
