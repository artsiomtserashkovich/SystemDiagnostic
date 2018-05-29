using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.Server.Controllers
{
    class TestController
    {
        public TestController() { }

        public ServerResponseInformation Test(ClientCommandInformation clientCommand)
        {
            Console.Write(DateTime.Now.ToString());
            Console.WriteLine(clientCommand.SerializedData);
            Console.WriteLine(clientCommand.ClientLogin.Login);

            return new ServerResponseInformation
            {
                Status = 999,
                SerializedData = "Success Test Command"
            };
        }
    }
}
