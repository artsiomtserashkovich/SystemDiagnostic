using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Attributes;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRServer;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Server.NetworkServer
{
    public class ServerCommandHandler : BaseServerCommandHandler
    {
        public ServerCommandHandler()
            : base(typeof(ServerCommandHandler)) { }


        [CRCommandHandler("Test")]
        public ServerResponseInformation TestHandleMethod(ClientCommandInformation clientCommand)
        {
            Console.Write(DateTime.Now.ToString());
            Console.WriteLine(clientCommand.SerializedData);
            Console.WriteLine(clientCommand.ClientLogin.Login);
            return new ServerResponseInformation
            {
                Status = 322,
                SerializedData = "Hellow world"
            };
        }

        [CRCommandHandler("RegisterComputerComponent")]
        public ServerResponseInformation RegisterComputerComponentHandleMethod
            (ClientCommandInformation clientCommand)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        [CRCommandHandler("GetComputerComponent")]
        public ServerResponseInformation GetComputerComponent
            (ClientCommandInformation clientCommand)
        {
            ComputerHardwareInformationDTO chInformation = JsonConvert
                .DeserializeObject<ComputerHardwareInformationDTO>(clientCommand.SerializedData);
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine(chInformation.ToString());
            return new ServerResponseInformation
            {
                Status = 1,
                SerializedData = "Success"
            };
        }

        [CRCommandHandler("GetTopPerfomanceProcesses")]
        public ServerResponseInformation GetTopPerfomanceProcesses
            (ClientCommandInformation clientCommand)
        {
            IEnumerable<ProcessPerfomanceDTO>  processesPerfomance 
                = JsonConvert.DeserializeObject<IEnumerable<ProcessPerfomanceDTO>>
                    (clientCommand.SerializedData);
            Console.WriteLine(DateTime.Now.ToString());
            foreach (ProcessPerfomanceDTO process in processesPerfomance)
                Console.WriteLine(process.ProcessId + " " + process.Name + " " 
                    + process.PercentCPUUsage + " " + process.RamMemoryUsageMB);
            return new ServerResponseInformation
            {
                Status = 1,
                SerializedData = "Success"
            };
        }
    }
}
