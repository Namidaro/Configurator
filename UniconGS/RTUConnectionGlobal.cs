using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NModbus4.Device;
using NModbus4.Serial;

namespace UniconGS
{
    public static class RTUConnectionGlobal
    {
        private static IModbusMaster _modbusMaster;
        public static Action OnWritingStartedAction { get; set; }
        public static Action OnWritingCompleteAction { get; set; }
        public static Action ConnectionLostAction { get; set; }

        public static void Initialize(IModbusMaster modbusMaster)
        {
            _modbusMaster = modbusMaster;
            _modbusMaster.Transport.RetryOnOldResponseThreshold = 5;
            _modbusMaster.Transport.Retries = 2;
            _modbusMaster.Transport.ReadTimeout = 10000;
            _modbusMaster.Transport.WriteTimeout = 10000;

            //_modbusMaster.Transport.ReadTimeout = 10000;
        }

        public static void CloseConnection()
        {
            _modbusMaster?.Dispose();
        }

        public static async Task SendDataByAddressAsync(byte numOfDevice, ushort address, ushort[] value)
        {
            if (_modbusMaster != null)
            {
                OnWritingStartedAction?.Invoke();
                try
                {
                    OnWritingStartedAction?.Invoke();
                    await _modbusMaster.WriteMultipleRegistersAsync(numOfDevice, address, value);
                }
                catch (Exception e)
                {
                    ConnectionLostAction?.Invoke();
                    throw;
                }
                finally
                {
                    OnWritingCompleteAction?.Invoke();
                }
            }
            else
            {
                throw new Exception("Не инициализирован обЪект связи");
            }
        }


        internal static async Task<ushort[]> GetDataByAddress(byte numOfDevice, ushort address, ushort value,
            bool isQueryCritical = true)
        {
            if (_modbusMaster != null)
            {
                OnWritingStartedAction?.Invoke();
                try
                {
                    ushort[] result;
                    result = await _modbusMaster.ReadHoldingRegistersAsync(numOfDevice, address, value);
                    return result;
                }
                catch (Exception e)
                {
                    if (isQueryCritical)
                    {
                        ConnectionLostAction?.Invoke();
                    }
                    throw e;
                }
                finally
                {

                    OnWritingCompleteAction?.Invoke();
                }
            }
            else
            {
                throw new Exception("Не инициализирован объект связи");
            }
        }
        public static async Task<byte[]> ExecuteFunction12Async(byte moduleNum, string requestName, byte innerFunctionId)
        {
            // TcpMbReadResponse tcpMbResponse;
            byte[] resultBytes = null;
            try
            {
                //TransactionCompleteAction?.Invoke();
                var receivedBytes = await _modbusMaster.ExecuteFunction12Async(1, moduleNum, innerFunctionId, 0);
                byte moduleByte = receivedBytes[0];
                byte innerFunByte = receivedBytes[1];
                byte numberOfBytesByte = receivedBytes[2];
                if ((moduleByte != moduleNum) || (innerFunByte != innerFunctionId))
                {
                    throw new Exception();
                }
                resultBytes = receivedBytes.Skip(3).ToArray();
            }
            catch
                (Exception j)
            {
                //AddErrorInList(j, requestName);
                //LastTransactionSucceed = false;
            }
            return resultBytes;
        }

        public static async Task ExecuteFunction15Async(byte numOfDevice, ushort address, bool[] data)
        {
            if (_modbusMaster != null)
            {
                OnWritingStartedAction?.Invoke();
                try
                {
                    OnWritingStartedAction?.Invoke();
                    await _modbusMaster.WriteMultipleCoilsAsync(numOfDevice, address, data);
                }
                catch (Exception e)
                {
                    ConnectionLostAction?.Invoke();
                    throw;
                }
                finally
                {
                    OnWritingCompleteAction?.Invoke();
                }
            }
            else
            {
                throw new Exception("Не инициализирован обЪект связи");
            }
        }
    }
}
