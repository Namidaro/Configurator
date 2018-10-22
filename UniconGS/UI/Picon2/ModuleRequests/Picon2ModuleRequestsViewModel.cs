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
using UniconGS.UI.Picon2.ModuleRequests.ModuleSpecification;
using System.ComponentModel;
using Innovative.SolarCalculator;

namespace UniconGS.UI.Picon2.ModuleRequests
{
    public class Picon2ModuleRequestsViewModel : BindableBase
    {
        #region [Private fields]
        private ObservableCollection<string> _moduleListForUI;
        private ObservableCollection<string> _moduleRequestsForUIList;
        private ObservableCollection<ModuleRequest> _requestsFromDevice;
        private ObservableCollection<ModuleRequest> _requestsToWrite;
        private ushort _requestCount;
        private List<string> _moduleList;
        private ModuleTypeList _moduleTypes;
        private ImageSRCList _imageSRC;
        private byte _msdCount;
        private byte _mrvCount;
        private byte _msaCount;
        private ObservableCollection<string> _imageSRCList;
        private ICommand _breakpointTestCommand;
        private ICommand _generateRequests;
        private ICommand _readFromDevice;
        private ICommand _writeToDevice;



        #endregion

        #region [CONST]
        private const ushort REQUEST_COUNT_ADDRESS = 0x300E;
        private const ushort MODULE_REQUEST_START_ADDRESS = 0x3080;
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
        /// Коллекция запросов для записи в устройство
        /// </summary>
        public ObservableCollection<ModuleRequest> RequestsToWrite
        {
            get { return _requestsToWrite; }
            set
            {
                _requestsToWrite = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Коллекция запросов из устройства
        /// </summary>
        public ObservableCollection<ModuleRequest> RequestsFromDevice
        {
            get { return _requestsFromDevice; }
            set
            {
                _requestsFromDevice = value;
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
        public ushort RequestCount
        {
            get { return _requestCount; }
            set
            {
                _requestCount = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Количество модулей МСД (для расчета адресов в базе)
        /// </summary>
        public byte MSDCount
        {
            get { return _msdCount; }
            set
            {
                _msdCount = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Количество модулей МРВ (для расчета адресов в базе)
        /// </summary>
        public byte MRVCount
        {
            get { return _mrvCount; }
            set
            {
                _mrvCount = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Количество модулей МСА (для расчета адресов в базе)
        /// </summary>
        public byte MSACount
        {
            get { return _msaCount; }
            set
            {
                _msaCount = value;
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

        /// <summary>
        /// Команда генерации запросов к модулям
        /// </summary>
        public ICommand GenerateRequests => this._generateRequests ??
            (this._generateRequests = new DelegateCommand(OnGenerateRequestsCommand));
        /// <summary>
        /// Команда чтения запросов из устройства
        /// </summary>
        public ICommand ReadFromDevice => this._readFromDevice ??
            (this._readFromDevice = new DelegateCommand(OnReadFromDeviceCommand));
        /// <summary>
        /// Команда записи запросов в устройство
        /// </summary>
        public ICommand WriteToDevice => this._writeToDevice ??
            (this._writeToDevice = new DelegateCommand(OnWriteToDeviceCommand));
        #endregion

        #region [Ctor]
        public Picon2ModuleRequestsViewModel()
        {
            this._moduleTypes = new ModuleTypeList();
            this._moduleList = new List<string>();
            this._moduleListForUI = new ObservableCollection<string>();
            this._imageSRC = new ImageSRCList();
            this._imageSRCList = new ObservableCollection<string>();
            this._moduleRequestsForUIList = new ObservableCollection<string>();
            this._requestsFromDevice = new ObservableCollection<ModuleRequest>();
            this._requestsToWrite = new ObservableCollection<ModuleRequest>();
            this.RequestCount = 0;
            this.MRVCount = 0;
            this.MSDCount = 0;
            this.MSACount = 0;
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

        /// <summary>
        /// Чтение запросов из устройства
        /// </summary>
        private async void OnReadFromDeviceCommand()
        {
            this.RequestsFromDevice.Clear();
            this.ModuleRequestsForUIList.Clear();
            // число запросов к модулям хранится по адресу 0х300Е, читаем 1 слово(2 байта)
            ushort[] RC = await RTUConnectionGlobal.GetDataByAddress(1, REQUEST_COUNT_ADDRESS, 1);
            RequestCount = RC[0];
            // начальный адрес
            ushort currentAddress = MODULE_REQUEST_START_ADDRESS;
            for (byte i = 0; i < RC[0]; i++)
            {
                RequestsFromDevice.Add(new ModuleRequest(await RTUConnectionGlobal.GetDataByAddress(1, currentAddress, 4)));
                ModuleRequestsForUIList.Add(RequestsFromDevice[i].UIRequest);
                currentAddress += 4;
            }
        }
        /// <summary>
        /// Запись запросов в устройство
        /// </summary>
        private async void OnWriteToDeviceCommand()
        {
            ushort[] RC = new ushort[] { RequestCount };
            await RTUConnectionGlobal.SendDataByAddressAsync(1, REQUEST_COUNT_ADDRESS, RC);
            //заглушка
            RequestsToWrite = RequestsFromDevice;
            ushort currentAddress = MODULE_REQUEST_START_ADDRESS;
            for (byte i = 0; i < RC[0]; i++)
            {
                await RTUConnectionGlobal.SendDataByAddressAsync(1, currentAddress, RequestsToWrite[i].Request);
                currentAddress += 4;
            }
        }
        /// <summary>
        ///  Генерация запросов по данным из UI
        /// </summary>
        private void OnGenerateRequestsCommand()
        {
            MSDCount = 0;
            MSACount = 0;
            MRVCount = 0;

            byte MSDUsed = 0;
            byte MSAUsed = 0;
            byte MRVUsed = 0;
            //для генерации ввести общее число запросов

            // сначала смотрим количество модулей МСД/МСА/МРВ
            for (byte i = 0; i < RequestCount; i++)
            {
                switch (GetModuleType(ModuleListForUI[i]))
                {
                    case (byte)ModuleSelectionEnum.MODULE_MSD980:
                        {
                            MSDCount++;
                            break;
                        }
                    case (byte)ModuleSelectionEnum.MODULE_MSA961:
                        {
                            MSACount++;
                            break;
                        }
                    case (byte)ModuleSelectionEnum.MODULE_MSA962:
                        {
                            MSACount++;
                            break;
                        }
                    case (byte)ModuleSelectionEnum.MODULE_MRV960:
                        {
                            MRVCount++;
                            break;
                        }
                    case (byte)ModuleSelectionEnum.MODULE_MRV980:
                        {
                            MRVCount++;
                            break;
                        }
                }
            }

            // заполняем список запросов для записи в устройство

            for (byte i = 0; i < RequestCount; i++)
            {
                IModuleRequest req;
                switch (GetModuleType(ModuleListForUI[i]))
                {
                    case (byte)ModuleSelectionEnum.MODULE_MSD980:
                        {
                            req = new MSD980ModuleSpecification() as IModuleRequest;
                            byte temp = (byte)(req.ParameterBaseAddress[1] + MSDUsed * req.ParameterCount);
                            req.ParameterBaseAddress[1] = temp;
                            RequestsToWrite.Add(new ModuleRequest(
                                0x00,
                                req.Type,
                                i,
                                req.Command,
                                req.ParameterModuleAddress,
                                req.ParameterBaseAddress,
                                req.ParameterCount));
                            MSDUsed++;
                            break;
                        }
                    case (byte)ModuleSelectionEnum.MODULE_MSA961:
                        {
                            req = new MSA961ModuleSpecification() as IModuleRequest;
                            byte temp = (byte)(req.ParameterBaseAddress[1] + MSAUsed * req.ParameterCount);
                            req.ParameterBaseAddress[1] = temp;
                            RequestsToWrite.Add(new ModuleRequest(
                                0x00,
                                req.Type,
                                i,
                                req.Command,
                                req.ParameterModuleAddress,
                                req.ParameterBaseAddress,
                                req.ParameterCount));
                            MSAUsed++;
                            break;
                        }
                    case (byte)ModuleSelectionEnum.MODULE_MSA962:
                        {
                            req = new MSA962ModuleSpecification() as IModuleRequest;
                            byte temp = (byte)(req.ParameterBaseAddress[1] + MSAUsed * req.ParameterCount);
                            req.ParameterBaseAddress[1] = temp;
                            RequestsToWrite.Add(new ModuleRequest(
                                0x00,
                                req.Type,
                                i,
                                req.Command,
                                req.ParameterModuleAddress,
                                req.ParameterBaseAddress,
                                req.ParameterCount));
                            MSAUsed++;
                            break;
                        }
                    case (byte)ModuleSelectionEnum.MODULE_MRV960:
                        {
                            req = new MRV960ModuleSpecification() as IModuleRequest;
                            byte temp = (byte)(req.ParameterBaseAddress[1] + MRVUsed * req.ParameterCount);
                            req.ParameterBaseAddress[1] = temp;
                            RequestsToWrite.Add(new ModuleRequest(
                                0x00,
                                req.Type,
                                i,
                                req.Command,
                                req.ParameterModuleAddress,
                                req.ParameterBaseAddress,
                                req.ParameterCount));
                            MRVUsed++;
                            break;
                        }
                    case (byte)ModuleSelectionEnum.MODULE_MRV980:
                        {
                            req = new MRV980ModuleSpecification() as IModuleRequest;
                            byte temp = (byte)(req.ParameterBaseAddress[1] + MRVUsed * req.ParameterCount);
                            req.ParameterBaseAddress[1] = temp;
                            RequestsToWrite.Add(new ModuleRequest(
                                0x00,
                                req.Type,
                                i,
                                req.Command,
                                req.ParameterModuleAddress,
                                req.ParameterBaseAddress,
                                req.ParameterCount));
                            MRVUsed++;
                            break;
                        }
                }

            }





        }

        #endregion

        #region [Converters]

        #endregion


    }
}
