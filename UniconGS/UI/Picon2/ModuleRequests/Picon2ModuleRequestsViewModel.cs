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
using System.ComponentModel;

namespace UniconGS.UI.Picon2.ModuleRequests
{
    public class Picon2ModuleRequestsViewModel : BindableBase
    {
        #region [Private fields]
        private ObservableCollection<string> _moduleListForUI;
        private List<string> _moduleList;
        private ModuleTypeList _moduleTypes;
        private ImageSRCList _imageSRC;
        private ObservableCollection<string> _imageSRCList;
        private ICommand _breakpointTestCommand;
        private ICommand _changeImageSRC;


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
        /// <summary>
        ///  
        /// </summary>
        public ICommand ChangeImageSRC => this._changeImageSRC ??
        (this._changeImageSRC = new DelegateCommand(OnChangeImageSRC));


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
            ModuleList = ModuleTypes.ModuleList.Keys.ToList() ;
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
        private void OnChangeImageSRC()
        {


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
        private void OnBreakpointTestCommand()
        {

        }





        #endregion


    }
}
