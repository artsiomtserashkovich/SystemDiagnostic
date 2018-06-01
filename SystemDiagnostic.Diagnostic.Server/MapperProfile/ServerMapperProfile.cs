using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using SystemDiagnostic.Diagnostic.DTO.Entities;
using SystemDiagnostic.Entitites.ComputerComponents;
using SystemDiagnostic.Entitites.MonitoringInformation;
using SystemDiagnostic.Entitites.OperatingInformation;

namespace SystemDiagnostic.Diagnostic.Server.MapperProfile
{
    class ServerMapperProfile : Profile
    {
        public ServerMapperProfile()
        {
            CreateMap<DiskDriveDTO, DiskDrive>()
                .ForMember(d => d.ComputerDiskDriveId, m => m.MapFrom(d => d.Id))
                .ForMember(d => d.MediaType, m => m.MapFrom(d => d.MediaType))
                .ForMember(d => d.Model, m => m.MapFrom(d => d.Model))
                .ForMember(d => d.SizeGB, m => m.MapFrom(d => d.SizeGB));

            CreateMap<VideoCardDTO, VideoCard>()
                .ForMember(v => v.Name, m => m.MapFrom(v => v.Name))
                .ForMember(v => v.VideoProcessor, m => m.MapFrom(v => v.VideoProcessor))
                .ForMember(v => v.AdapterCompatibility, m => m.MapFrom(v => v.AdapterCompatibility))
                .ForMember(v => v.AdapterRAMGB, m => m.MapFrom(v => v.AdapterRAMGB))
                .ForMember(v => v.MaxRefreshRate, m => m.MapFrom(v => v.MaxRefreshRate));

            CreateMap<ProcessorDTO, Processor>()
                .ForMember(p => p.Architecture, m => m.MapFrom(p => p.Architecture))
                .ForMember(p => p.ClockFrequency, m => m.MapFrom(p => p.ClockFrequency))
                .ForMember(p => p.ComputerProcessorId, m => m.MapFrom(p => p.Id))
                .ForMember(p => p.Description, m => m.MapFrom(p => p.Description))
                .ForMember(p => p.Name, m => m.MapFrom(p => p.Name))
                .ForMember(p => p.NumberOfCores, m => m.MapFrom(p => p.NumberOfCores))
                .ForMember(p => p.L2CacheSize, m => m.MapFrom(p => p.L2CacheSize))
                .ForMember(p => p.L3CacheSize, m => m.MapFrom(p => p.L3CacheSize));

            CreateMap<MotherBoardDTO, MotherBoard>()
                .ForMember(m => m.ComputerMotherBoardId, m => m.MapFrom(d => d.Id))
                .ForMember(m => m.Manufacturer, m => m.MapFrom(d => d.Manufacturer))
                .ForMember(m => m.Product, m => m.MapFrom(d => d.Product));

            CreateMap<PhysicalMemoryDTO, PhysicalMemory>()
                .ForMember(p => p.ComputerPhysicalMemoryId, m => m.MapFrom(p => p.Id))
                .ForMember(p => p.Manufacturer, m => m.MapFrom(p => p.Manufacurer))
                .ForMember(p => p.Speed, m => m.MapFrom(p => p.Speed))
                .ForMember(p => p.FormFactor, m => m.MapFrom(p => p.FormFactor))
                .ForMember(p => p.CapacityGB, m => m.MapFrom(p => p.CapacityGB));

            CreateMap<ComputerSystemDTO, ComputerSystem>()
                .ForMember(p => p.ComputerName, m => m.MapFrom(p => p.ComputerName))
                .ForMember(p => p.CurrentUsername, m => m.MapFrom(p => p.CurrentUsername))
                .ForMember(p => p.DNSHostName, m => m.MapFrom(p => p.DNSHostName))
                .ForMember(p => p.OperatingSystemName, m => m.MapFrom(p => p.OSName));

            CreateMap<ProcessInformationDTO, ProcessInformation>()
                .ForMember(p => p.CommandLine, m => m.MapFrom(p => p.CommandLine))
                .ForMember(p => p.Description, m => m.MapFrom(p => p.Description))
                .ForMember(p => p.Path, m => m.MapFrom(p => p.Path));

            CreateMap<ProcessPerfomanceDTO, ProcessPerfomance>()
                .ForMember(p => p.PercentCPUUsage, m => m.MapFrom(p => p.PercentCPUUsage))
                .ForMember(p => p.RamMemoryUsageMB, m => m.MapFrom(p => p.RamMemoryUsageMB));                
        }
    }
}
