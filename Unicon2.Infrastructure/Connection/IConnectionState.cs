﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Unicon2.Infrastructure.DeviceInterfaces;
using Unicon2.Infrastructure.Interfaces.Values;
using Unicon2.Infrastructure.Services.LogService;
using Unicon2.Infrastructure.Values;

namespace Unicon2.Infrastructure.Connection
{
    public interface IConnectionState:ICloneable
    {
        bool IsConnected { get; }
        bool GetIsExpectedValueMatchesDevice();
        Action ConnectionStateChangedAction { get; set; }
        Task CheckConnection();
        IFormattedValue TestResultValue { get; set; }
        IDeviceValueContaining DeviceValueContaining { get; set; }
        List<string> ExpectedValues { get; set; }
        IComPortConfiguration DefaultComPortConfiguration { get; set; }
        void Initialize(IDeviceConnection deviceConnection, IDeviceLogger deviceLogger,IUnityContainer container);
        Task TryReconnect();
    }
}
