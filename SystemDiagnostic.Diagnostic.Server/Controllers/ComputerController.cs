using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;
using SystemDiagnostic.Diagnostic.DTO.Entities;
using SystemDiagnostic.Diagnostic.Server.Services.Exceptions;

namespace SystemDiagnostic.Diagnostic.Server.Controllers
{
    public class ComputerController
    {
        public ComputerController() { }

        public ServerResponseInformation RecieveComputerHardwareInformation
            (ComputerHardwareInformationDTO computeHardwareInformation)
        {
            try
            {
                Console.WriteLine(computeHardwareInformation.Processor.Architecture);
                Console.WriteLine(computeHardwareInformation.Processor.Name);
                Console.WriteLine(computeHardwareInformation.MotherBoard.Manufacturer);
                Console.WriteLine(computeHardwareInformation.MotherBoard.Product);
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
            finally
            {

            }
        }

        public ServerResponseInformation RecieveComputerOperatingInformation
            (ComputerOperatingInformationDTO computerOperatingInformation)
        {
            try
            {
                Console.WriteLine(computerOperatingInformation.ComputerInformation.ComputerName);
                Console.WriteLine(computerOperatingInformation.ComputerInformation.CurrentUsername);
                Console.WriteLine(computerOperatingInformation.ComputerInformation.DNSHostName);
                Console.WriteLine(computerOperatingInformation.ComputerInformation.OSName);
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
            finally
            {

            }
        }

    }
}
