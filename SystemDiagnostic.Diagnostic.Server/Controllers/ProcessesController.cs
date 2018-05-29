using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;
using SystemDiagnostic.Diagnostic.DTO.Entities;
using SystemDiagnostic.Diagnostic.Server.Services.Exceptions;

namespace SystemDiagnostic.Diagnostic.Server.Controllers
{
    public class ProcessesController
    {
        public ProcessesController() { }

        public ServerResponseInformation RecieveProcessesPerfomance(IEnumerable<ProcessPerfomanceDTO> processesPerfomance)
        {
            try
            {
                foreach (ProcessPerfomanceDTO process in processesPerfomance)
                {
                    Console.WriteLine(process.ProcessId);
                    Console.WriteLine(process.Name);
                    Console.WriteLine(process.PercentCPUUsage);
                    Console.WriteLine(process.RamMemoryUsageMB);
                }
                return new ServerResponseInformation
                {
                    Status = 1,
                    SerializedData = "Success"
                };
            }
            catch(ServerServicesException exception)
            {
                return new ServerResponseInformation
                {
                    Status = -1,
                    SerializedData = exception.Message
                };
            }            
        }
        
        public ServerResponseInformation RecieveProcesses(IEnumerable<ProcessDTO> processes)
        {
            try
            {
                foreach (ProcessDTO process in processes)
                {
                    Console.WriteLine(process.ProcessId);
                    Console.WriteLine(process.Information.Name);
                    Console.WriteLine(process.Information.Path);
                    Console.WriteLine(process.Information.CommandLine);
                    Console.WriteLine(process.Information.CreationDate);
                    Console.WriteLine(process.Information.Description);
                    Console.WriteLine(process.PerfomanceInformation.PercentCPUUsage);
                    Console.WriteLine(process.PerfomanceInformation.RamMemoryUsageMB);
                }
                return new ServerResponseInformation
                {
                    Status = 1,
                    SerializedData = "Success"
                };
            }
            catch (ServerServicesException exception)
            {
                return new ServerResponseInformation
                {
                    Status = -1,
                    SerializedData = exception.Message
                };
            }
        }
    }
}
