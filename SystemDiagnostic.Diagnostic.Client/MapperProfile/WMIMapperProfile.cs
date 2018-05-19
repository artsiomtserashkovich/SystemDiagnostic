using System;
using AutoMapper;
using AutoMapper.Configuration;
using SystemDiagnostic.Diagnostic.Client.WMI;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Managers;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Client.MapperProfile
{
    public class WMIMapperProfile : Profile
    {
        public WMIMapperProfile()
        {
            CreateMap<WMIComputerSystem, ComputerSystemDTO>()
                .ForMember(d => d.ComputerName, m => m.MapFrom(k => k.Name))
                .ForMember(d => d.CurrentUsername, m => m.MapFrom(k => k.UserName))
                .ForMember(d => d.DNSHostName, m => m.MapFrom(k => k.DNSHostName))
                .ForMember(d => d.OSName, m => m.MapFrom(k => k.SystemFamily));

            CreateMap<WMIProcessor, ProcessorDTO>()
                .ForMember(d => d.Id, m => m.MapFrom(k => k.Id))
                .ForMember(d => d.ClockFrequency, m => m.MapFrom(k => k.ClockFrequency))
                .ForMember(d => d.Description, m => m.MapFrom(k => k.Description))
                .ForMember(d => d.Architecture, m => m.MapFrom(k => WMIConverter.ConvertArchitecture(k.Architecture)))
                .ForMember(d => d.L2CacheSize, m => m.MapFrom(k => k.L2Cache))
                .ForMember(d => d.L3CacheSize, m => m.MapFrom(k => k.L3Cache))
                .ForMember(d => d.Name, m => m.MapFrom(k => k.Name))
                .ForMember(d => d.NumberOfCores, m => m.MapFrom(k => k.NumberOfCores));

            CreateMap<WMIPhysicalMemory, PhysicalMemoryDTO>()
                .ForMember(d => d.CapacityGB, m => m.MapFrom(
                    v => WMIConverter.ConvertFromBytestoGB(v.Capacity)));

            CreateMap<WMIDiskDrive, DiskDriveDTO>()
                .ForMember(d => d.SizeGB, m => m.MapFrom(g => WMIConverter.ConvertFromBytestoGB(g.Size)));

            CreateMap<WMIBaseBoard, MotherBoardDTO>();

            CreateMap<WMIPerfDataProcess, ProcessDTO>()
                .ForMember(d => d.PercentProcessorTime, m => m.MapFrom(d => d.PercentProcessorTime));

            CreateMap<WMIProcess, ProcessDTO>()
                .ForMember(d => d.CreationDate, m => m.MapFrom(d => d.CreatinDate))
                .ForMember(d => d.PeakVirtualSizeMB, m => m.MapFrom(d => WMIConverter.ConvertFromBytestoMB(d.PeakVirtualSizeBytes)))
                .ForMember(d => d.PeakWorkingSetSizeMB, m => m.MapFrom(d => WMIConverter.ConvertFromKBtoMB(d.PeakWorkingSetSizeKB)))
                .ForMember(d => d.ProcessId, m => m.MapFrom(d => d.Id))
                .ForMember(d => d.VirtualSizeMB, m => m.MapFrom(d => WMIConverter.ConvertFromBytestoMB(d.VirtualSizeBytes)))
                .ForMember(d => d.WorkingSetSizeMB, m => m.MapFrom(d => WMIConverter.ConvertFromKBtoMB(d.WorkingSetSizeKB)));


            CreateMap<WMIVideoController, VideoCardDTO>()
                .ForMember(d => d.AdapterRAMGB, m => m.MapFrom(
                g => WMIConverter.ConvertFromBytestoGB(g.AdapterRAM)));
        }
    }
}
