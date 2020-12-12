using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ThinkerThings.Core.DTOs.Devices.AirConditionerDto;
using ThinkerThings.Core.DTOs.Devices.MotionSensorDto;
using ThinkerThings.Core.DTOs.Devices.SmartLampDto;
using ThinkerThings.Core.DTOs.GatewayDto;
using ThinkerThings.Core.DTOs.MotionDateDto;
using ThinkerThings.Core.DTOs.NetworkDto;
using ThinkerThings.Core.DTOs.UserDto;
using ThinkerThings.Core.Entities;
using ThinkerThings.Core.Entities.Devices;

namespace ThinkerThings.API.Mappig
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateUserDto,User>();

            CreateMap<NetworkDto, Network>();
            CreateMap<Network, NetworkDto>();

            CreateMap<MotionDate, MotionDateDto>();
            CreateMap<MotionDateDto, MotionDate>();

            CreateMap<Gateway, GatewayDto>();
            CreateMap<GatewayDto, Gateway>();

            CreateMap<AirConditioner, AirConditionerCreateDto>();
            CreateMap<AirConditionerCreateDto, AirConditioner>();
            CreateMap<AirConditioner, AirConditionerCreateDto>();
            CreateMap<AirConditionerCreateDto, AirConditioner>();

            CreateMap<SmartLamp, SmartLampDto>();
            CreateMap<SmartLampDto, SmartLamp>();

            CreateMap<MotionSensor, MotionSensorDto>();
            CreateMap<MotionSensorDto, MotionSensor>();
            CreateMap<MotionSensor, MotionSensorCreateDtoDto>();
            CreateMap<MotionSensorCreateDtoDto, MotionSensor>();
        }
    }
}
