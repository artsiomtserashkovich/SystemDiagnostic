using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Attributes;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRServer.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRServer;

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
    }
}
