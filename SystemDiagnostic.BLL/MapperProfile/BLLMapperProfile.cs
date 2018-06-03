using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites;
using SystemDiagnostic.Entitites.OperatingInformation;
using SystemDiagnostic.ViewModel;

namespace SystemDiagnostic.BLL.MapperProfile
{
    public class BLLMapperProfile : Profile
    {
        public BLLMapperProfile()
        {
            CreateMap<Computer, ComputerViewModel>()
                .ForMember(c => c.Id, m => m.MapFrom(c => c.Id))
                .ForMember(c => c.Login, m => m.MapFrom(c => c.Login))
                .ForMember(c => c.IsConnected, m => m.MapFrom(c => c.IsConnected));

            CreateMap<ComputerSystem, ComputerSystemViewModel>()
                .ForMember(c => c.Id, m => m.MapFrom(c => c.Id))
                .ForMember(c => c.ComputerName, m => m.MapFrom(c => c.ComputerName))
                .ForMember(c => c.ComputerId, m => m.MapFrom(c => c.ComputerId))
                .ForMember(c => c.CurrentUsername, m => m.MapFrom(c => c.CurrentUsername))
                .ForMember(c => c.DNSHostName, m => m.MapFrom(c => c.DNSHostName));
        }

    }
}
