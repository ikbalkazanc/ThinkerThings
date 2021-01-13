using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkerThings.API.RTC.SignalR.Contracts
{
    public interface IAirConditionerHub
    {
        Task ToggleAirConditioner(string message);
        Task GetTempature(string message);
        Task SetSpeed(string message);
    }
}
