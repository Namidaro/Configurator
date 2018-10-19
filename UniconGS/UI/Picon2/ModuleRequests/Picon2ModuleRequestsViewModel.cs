using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using UniconGS.Enums;
using UniconGS.UI.Picon2.ModuleRequests.Resources;
using System.ComponentModel;
using Innovative.SolarCalculator;

namespace UniconGS.UI.Picon2.ModuleRequests
{
    public class Picon2ModuleRequestsViewModel : BindableBase
    {
        #region [Private fields]
        private ObservableCollection<string> _moduleListForUI;
        private ObservableCollection<string> _moduleRequestsForUIList;
        private List<string> _moduleList;
        private ModuleTypeList _moduleTypes;
        private ImageSRCList _imageSRC;
        private ObservableCollection<string> _imageSRCList;
        private ICommand _breakpointTestCommand;

        #endregion

        #region [Properties]
        /// <summary>
        /// SortedList из всех типов модулей в паре ключ-значение, где ключ - строка кириллицей, значение - цифровое значение enum для дальнейшей обработки
        /// </summary>
        public ModuleTypeList ModuleTypes
        {
            get
            {
                return _moduleTypes;
            }
        }
        /// <summary>
        /// SortedList из всех типов модулей в паре ключ-значение, где ключ - цифровое значение enum, значение - строка--ссылка на изображение
        /// </summary>
        public ImageSRCList ImageSRC
        {
            get { return _imageSRC; }
        }
        /// <summary>
        /// Список модулей для комбобокса в UI
        /// </summary>
        public List<string> ModuleList
        {
            get { return _moduleList; }
            set
            {
                _moduleList = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Содержит список модулей, выбранных в UI, изначально весь список состоит из "Заглушек"
        /// </summary>
        public ObservableCollection<string> ModuleListForUI
        {
            get { return _moduleListForUI; }
            set
            {
                _moduleListForUI = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Содержит список запросов, выводимый на экран
        /// </summary>
        public ObservableCollection<string> ModuleRequestsForUIList
        {
            get { return _moduleRequestsForUIList; }
            set
            {
                _moduleRequestsForUIList = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Список ссылок на изображения модулей, должен быть привязан к выбраным модулям в UI
        /// </summary>
        public ObservableCollection<string> ImageSRCList
        {
            get { return _imageSRCList; }
            set
            {
                _imageSRCList = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region [NavigateCommands]
        /// <summary>
        /// Кнопка для отладки
        /// </summary>
        public ICommand BreakpointTestCommand => this._breakpointTestCommand ??
            (this._breakpointTestCommand = new DelegateCommand(OnBreakpointTestCommand));

        #endregion

        #region [Ctor]
        public Picon2ModuleRequestsViewModel()
        {
            this._moduleTypes = new ModuleTypeList();
            this._moduleList = new List<string>();
            this._moduleListForUI = new ObservableCollection<string>();
            this._imageSRC = new ImageSRCList();
            this._imageSRCList = new ObservableCollection<string>();
            InitializeModuleList();
            InitializeImageList();


        }
        #endregion

        #region [Methods]
        /// <summary>
        /// инициализация элементов списка для UI
        /// </summary>
        private void InitializeModuleList()
        {
            ModuleList = ModuleTypes.ModuleList.Keys.ToList();
            for (byte i = 0; i < 16; i++)
            {
                ModuleListForUI.Add(ModuleList.First());
            }
        }
        /// <summary>
        /// инициализация списка изображений
        /// </summary>
        private void InitializeImageList()
        {
            for (byte i = 0; i < 16; i++)
            {
                ImageSRCList.Add(GetImageSRC((byte)ModuleSelectionEnum.MODULE_EMPTY));
            }
            ImageSRCList.Add(GetImageSRC((byte)ModuleSelectionEnum.MODULE_SERVICE_POWERSUPPLY));
            ImageSRCList.Add(GetImageSRC((byte)ModuleSelectionEnum.MODULE_SERVICE_CPU));

        }
        /// <summary>
        ///  Получить численное значение типа модуля по его имени, см ModuleSelectionEnum
        /// </summary>
        /// <param name="ModuleName"></param>
        /// <returns></returns>
        public byte GetModuleType(string ModuleName)
        {
            if (ModuleTypes.ModuleList.ContainsKey(ModuleName))
            {
                return (byte)ModuleTypes.ModuleList.ElementAt(ModuleTypes.ModuleList.IndexOfKey(ModuleName)).Value;
            }
            else
                return 0;
        }
        /// <summary>
        /// Получить строковое значение ссылки на изображение по его типу
        /// </summary>
        /// <param name="ModuleEnum"></param>
        /// <returns></returns>
        public string GetImageSRC(byte ModuleEnum)
        {
            if (ImageSRC.ImageList.ContainsKey(ModuleEnum))
            {
                return ImageSRC.ImageList.ElementAt(ImageSRC.ImageList.IndexOfKey(ModuleEnum)).Value;
            }
            else
                return "";
        }

        #endregion

        #region [UICommands]
        /// <summary>
        /// команда для отладки и проверки значений свойств, удалить по окончании
        /// </summary>
        private async void OnBreakpointTestCommand()
        {
            ushort[] RequestCount = await RTUConnectionGlobal.GetDataByAddress(1, 0x300E, 1);
            ushort startAddress = 0x3080;
            ushort currentAddress;
            currentAddress = startAddress;
            ObservableCollection<ModuleRequest> requests = new ObservableCollection<ModuleRequest>();

            for (byte i = 0; i < RequestCount[0]; i++)
            {

                requests.Add(new ModuleRequest(await RTUConnectionGlobal.GetDataByAddress(1, currentAddress, 4)));
                currentAddress += 4;

            }


            //ModuleRequest req = new ModuleRequest();
            //ModuleRequest req2 = new ModuleRequest(0x00, 0x0F, 0x07, 0x20, 0x0000, 0x2000, 0x0C);
            //req2.SpreadRequest();
            //ModuleRequest req3 = new ModuleRequest();


            //TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            //TimeZoneInfo cst = TimeZoneInfo.Local;

            //DateTime jan = new DateTime(2018, 1, 15);
            //DateTime feb = new DateTime(2018, 2, 15);
            //DateTime mar = new DateTime(2018, 3, 15);
            //DateTime apr = new DateTime(2018, 4, 15);
            //DateTime may = new DateTime(2018, 5, 15);
            //DateTime jun = new DateTime(2018, 6, 15);
            //DateTime jul = new DateTime(2018, 7, 15);
            //DateTime aug = new DateTime(2018, 8, 15);
            //DateTime sep = new DateTime(2018, 9, 15);
            //DateTime oct = new DateTime(2018, 10, 15);
            //DateTime nov = new DateTime(2018, 11, 15);
            //DateTime dec = new DateTime(2018, 12, 15);




            //SolarTimes solarTimes = new SolarTimes(DateTime.Now.Date, 53.8622, 27.6060);
            //DateTime sunrise = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunrise.ToUniversalTime(), cst);
            //DateTime sunset = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), cst);


            //solarTimes = new SolarTimes(jan, 53.8622, 27.6060);
            //sunrise = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunrise.ToUniversalTime(), cst);
            //sunset = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), cst);
            //solarTimes = new SolarTimes(feb, 53.8622, 27.6060);
            //sunrise = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunrise.ToUniversalTime(), cst);
            //sunset = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), cst);
            //solarTimes = new SolarTimes(mar, 53.8622, 27.6060);
            //sunrise = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunrise.ToUniversalTime(), cst);
            //sunset = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), cst);
            //solarTimes = new SolarTimes(apr, 53.8622, 27.6060);
            //sunrise = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunrise.ToUniversalTime(), cst);
            //sunset = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), cst);
            //solarTimes = new SolarTimes(may, 53.8622, 27.6060);
            //sunrise = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunrise.ToUniversalTime(), cst);
            //sunset = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), cst);
            //solarTimes = new SolarTimes(jun, 53.8622, 27.6060);
            //sunrise = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunrise.ToUniversalTime(), cst);
            //sunset = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), cst);
            //solarTimes = new SolarTimes(jul, 53.8622, 27.6060);
            //sunrise = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunrise.ToUniversalTime(), cst);
            //sunset = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), cst);
            //solarTimes = new SolarTimes(aug, 53.8622, 27.6060);
            //sunrise = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunrise.ToUniversalTime(), cst);
            //sunset = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), cst);
            //solarTimes = new SolarTimes(sep, 53.8622, 27.6060);
            //sunrise = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunrise.ToUniversalTime(), cst);
            //sunset = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), cst);
            //solarTimes = new SolarTimes(oct, 53.8622, 27.6060);
            //sunrise = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunrise.ToUniversalTime(), cst);
            //sunset = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), cst);
            //solarTimes = new SolarTimes(nov, 53.8622, 27.6060);
            //sunrise = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunrise.ToUniversalTime(), cst);
            //sunset = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), cst);
            //solarTimes = new SolarTimes(dec, 53.8622, 27.6060);
            //sunrise = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunrise.ToUniversalTime(), cst);
            //sunset = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), cst);

            //sunrise = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunrise.ToUniversalTime(), cst);
            //sunset = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), cst);


        }





        #endregion

        #region [Converters]
        /// <summary>
        /// Перевод из Hex в Dec (может понадобиться)
        /// </summary>
        /// <param name="Hex"></param>
        /// <returns></returns>
        private byte ConvertFromHexToDec(byte Hex)
        {
            string hexValueStr = Hex.ToString("X");
            byte decValue = byte.Parse(hexValueStr, System.Globalization.NumberStyles.HexNumber);
            return decValue;
        }
        /// <summary>
        /// Перевод из Dec в Hex (может понадобиться)
        /// </summary>
        /// <param name="Dec"></param>
        /// <returns></returns>
        private byte ConvertFromDecToHex(byte Dec)
        {
            string hexValueStr = Dec.ToString("D");
            byte hexValue = Convert.ToByte(hexValueStr, 16);
            return hexValue;
        }
        #endregion


    }
}
