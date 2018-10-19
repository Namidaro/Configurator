using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniconGS.UI.Picon2.ModuleRequests.Resources
{
    public class ModuleRequest : IModuleRequest
    {
        #region [Properties]
        public byte Period { get; set; }
        public byte Type { get; set; }
        public byte CrateAddress { get; set; }
        public byte Command { get; set; }
        public byte[] ParameterModuleAddress { get; set; }
        public byte[] ParameterBaseAddress { get; set; }
        public byte ParameterCount { get; set; }
        public ushort[] Request { get; set; }
        public string UIRequest { get; set; }
        #endregion
        #region [Ctor's]
        public ModuleRequest()
        {
            Period = 0x00;
            Type = 0x00;
            CrateAddress = 0x00;
            Command = 0x00;
            ParameterModuleAddress = new byte[2] { 0x00, 0x00 };
            ParameterBaseAddress = new byte[2] { 0x00, 0x00 };
            ParameterCount = 0x00;
            UIRequest = String.Empty;
        }

        public ModuleRequest(byte _period,
                            byte _type,
                            byte _crateAddress,
                            byte _command,
                            byte[] _paramModAddr,
                            byte[] _paramBaseAddr,
                            byte _paramCount)
        {
            Period = _period;
            Type = _type;
            CrateAddress = _crateAddress;
            Command = _command;
            ParameterModuleAddress = _paramModAddr;
            ParameterBaseAddress = _paramBaseAddr;
            ParameterCount = _paramCount;

            CreateRequest();
            GenerateUIRequest();
        }

        public ModuleRequest(byte _period,
                           byte _type,
                           byte _crateAddress,
                           byte _command,
                           ushort _paramModAddr,
                           ushort _paramBaseAddr,
                           byte _paramCount)
        {
            Period = _period;
            Type = _type;
            CrateAddress = _crateAddress;
            Command = _command;
            ParameterModuleAddress = new byte[2] { (byte)(_paramModAddr << 8), (byte)(_paramModAddr >> 8) };
            ParameterBaseAddress = new byte[2] { (byte)(_paramBaseAddr << 8), (byte)(_paramBaseAddr >> 8) };
            ParameterCount = _paramCount;

            CreateRequest();
            GenerateUIRequest();
        }

        public ModuleRequest(ushort[] req)
        {
            Request = req;
            byte[] reqArray = ArrayExtension.UshortArrayToByteArray(Request);

            SpreadRequest(reqArray);
            GenerateUIRequest();
        }
        #endregion
        #region [Methods]
        public void CreateRequest()
        {
            try
            {
                List<byte> req = new List<byte>();
                req.Add(Period);
                req.Add((byte)((Type << 4) + CrateAddress));
                req.Add(Command);
                req.AddRange(ParameterModuleAddress);
                req.AddRange(ParameterBaseAddress);
                req.Add(ParameterCount);
                Request = ArrayExtension.ByteArrayToUshortArray(req.ToArray());
            }
            catch { }
        }

        public void SpreadRequest(byte[] req)
        {
            try
            {
                Period = 0x00;
                Type = 0x00;
                CrateAddress = 0x00;
                Command = 0x00;
                ParameterModuleAddress = new byte[2] { 0x00, 0x00 };
                ParameterBaseAddress = new byte[2] { 0x00, 0x00 };
                ParameterCount = 0x00;
                ArrayExtension.SwapArrayItems(ref req);
                if (req.Count() == 8)
                {
                    Period = Converters.Convert.ConvertFromDecToHex(req[0]);
                    Type = Converters.Convert.HIHALFBYTE(Converters.Convert.ConvertFromDecToHex(req[1]));
                    CrateAddress = Converters.Convert.LOHALFBYTE(Converters.Convert.ConvertFromDecToHex(req[1]));
                    Command = Converters.Convert.ConvertFromDecToHex(req[2]);
                    ParameterModuleAddress[0] = Converters.Convert.ConvertFromDecToHex(req[3]);
                    ParameterModuleAddress[1] = Converters.Convert.ConvertFromDecToHex(req[4]);
                    ParameterBaseAddress[0] = Converters.Convert.ConvertFromDecToHex(req[5]);
                    ParameterBaseAddress[1] = Converters.Convert.ConvertFromDecToHex(req[6]);
                    ParameterCount = Converters.Convert.ConvertFromDecToHex(req[7]);
                }
            }
            catch { }
        }

        private string GenerateUIRequest()
        {
            StringBuilder sb = new StringBuilder();








            return "";
        }



        #endregion
    }
}