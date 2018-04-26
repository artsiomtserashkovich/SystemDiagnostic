using System;
using AutoMapper;
using AutoMapper.Configuration;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Client.MapperProfile
{
    public class WMIMapperProfile : Profile
    {
        public WMIMapperProfile(){
            CreateMap<WMIProcessor,ProcessorDTO>()
            .ForMember(d => d.Id,m => m.MapFrom(k => k.Id))
            .ForMember(d => d.ClockFrequency,m => m.MapFrom(k => k.ClockFrequency))
            .ForMember(d => d.Description,m => m.MapFrom(k => k.Description))
            .ForMember(d => d.Architecture,m => m.MapFrom(k => k.Architecture.ToString()))
            .ForMember(d => d.L2CacheSize,m => m.MapFrom(k => k.L2Cache))
            .ForMember(d => d.L3CacheSize,m => m.MapFrom(k => k.L3Cache))
            .ForMember(d => d.Name,m => m.MapFrom(k => k.Name))
            .ForMember(d => d.NumberOfCores,m => m.MapFrom(k => k.NumberOfCores));

            CreateMap<WMIPhysicalMemory,PhysicalMemoryDTO>();
        }
    }
}
