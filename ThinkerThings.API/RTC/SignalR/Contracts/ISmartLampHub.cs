using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkerThings.API.RTC.SignalR.Contracts
{
    public interface ISmartLampHub
    {
        Task ToggleLamp(string command);
    }
}
