using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ThinkerThings.Core.DTOs.Devices.AirConditionerDto;
using ThinkerThings.Core.DTOs.Devices.MotionSensorDto;
using ThinkerThings.Core.DTOs.Devices.SmartLampDto;
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
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<NetworkDto, Network>().ReverseMap();
            CreateMap<MotionDate, MotionDateDto>().ReverseMap();
            CreateMap<AirConditioner, AirConditionerCreateDto>().ReverseMap();
            CreateMap<AirConditioner, AirConditionerDto>().ReverseMap();
            CreateMap<SmartLamp, SmartLampDto>().ReverseMap();
            CreateMap<MotionSensor, MotionSensorDto>().ReverseMap();
            CreateMap<MotionSensor, MotionSensorCreateDto>().ReverseMap();

        }
    }
}
