using System;
using SystemDiagnostic.Diagnostic.DTO.CommandHandlerEntities;

namespace SystemDiagnostic.Diagnostic.Client.NetworkClient.Handlers
{
    public class CommandsHandler
    {
        private NetworkClient networkClient { get; set; }

        public CommandsHandler(NetworkClient client)
        {
            networkClient = client;
        }

        internal ClientResponse RecieveCommand(ServerCommand serverCommand)
        {
            throw new NotImplementedException();
        }

        internal void RecieveResponse(ServerResponse serverResponse)
        {
            throw new NotImplementedException();
        }
    }
}
