using System;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRServer.Interfaces;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Interfaces;
using SystemDiagnostic.Diagnostic.Server.NetworkServer;

namespace SystemDiagnostic.Diagnostic.Server
{
    class Program
    {   public static void Main()
        {
            IServiceCollection service = new ServiceCollection();
            ConfigureServices(service);    
            IServerCommandHandler serverCommandHandler = new ServerCommandHandler();
            IServer server = new CommandResponseProtocol.CRServer.Server(serverCommandHandler);
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 3567;
            int countClients = 10;
            server.Run(ip,port,countClients);       
        }

        private static void ConfigureServices(IServiceCollection service)
        {
        
        }   
    }
}
