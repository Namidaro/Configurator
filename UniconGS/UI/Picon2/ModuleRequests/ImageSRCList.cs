using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniconGS.Enums;

namespace UniconGS.UI.Picon2.ModuleRequests
{
    public class ImageSRCList
    {
        public SortedList<byte, string> ImageList = new SortedList<byte, string>();

        public ImageSRCList()
        {
            InitializeImageList();
        }

        private void InitializeImageList()
        {
            ImageList.Add((byte)(ModuleSelectionEnum.MODULE_EMPTY),"Images/Image_EMPTY.png");
            ImageList.Add((byte)(ModuleSelectionEnum.MODULE_MRV960), "Images/Image_MRV960.png");
            ImageList.Add((byte)(ModuleSelectionEnum.MODULE_MRV980), "Images/Image_MRV980.png");
            ImageList.Add((byte)(ModuleSelectionEnum.MODULE_MS911), "Images/Image_MS911.png");
            ImageList.Add((byte)(ModuleSelectionEnum.MODULE_MS911R), "Images/Image_MS911R.png");
            ImageList.Add((byte)(ModuleSelectionEnum.MODULE_MS915), "Images/Image_MS915.png");
            ImageList.Add((byte)(ModuleSelectionEnum.MODULE_MS916), "Images/Image_MS916.png");
            ImageList.Add((byte)(ModuleSelectionEnum.MODULE_MS917), "Images/Image_MS917.png");
            ImageList.Add((byte)(ModuleSelectionEnum.MODULE_MSA961), "Images/Image_MSA961.png");
            ImageList.Add((byte)(ModuleSelectionEnum.MODULE_MSA962), "Images/Image_MSA962.png");
            ImageList.Add((byte)(ModuleSelectionEnum.MODULE_MSD980), "Images/Image_MSD980.png");
            ImageList.Add((byte)(ModuleSelectionEnum.MODULE_MII901), "Images/Image_MII901.png");
            ImageList.Add((byte)(ModuleSelectionEnum.MODULE_SERVICE_POWERSUPPLY), "Images/Image_PowerSupply.png");
            ImageList.Add((byte)(ModuleSelectionEnum.MODULE_SERVICE_CPU), "Images/Image_CPU.png");

        }
    }
}
