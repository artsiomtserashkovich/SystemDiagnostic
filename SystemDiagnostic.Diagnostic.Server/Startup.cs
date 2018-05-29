using System;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRServer.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRServer.Interfaces;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Interfaces;
using SystemDiagnostic.Diagnostic.Server.Controllers;
using SystemDiagnostic.Diagnostic.Server.NetworkServer;

namespace SystemDiagnostic.Diagnostic.Server
{
    class Program
    {   public static void Main()
        {
            IServiceCollection service = new ServiceCollection();
            ConfigureServices(service);
            ServiceProvider serviceProvider = service.BuildServiceProvider();
            IServerCommandHandler serverCommandHandler = new ServerCommandHandler(serviceProvider);
            IServer server = new CommandResponseProtocol.CRServer.Server(serverCommandHandler);
            RunPropertyModel runPropertyModel = InputAdress();
            server.Run(runPropertyModel);       
        }

        private static void ConfigureServices(IServiceCollection service)
        {
            service.AddTransient<AuthorizeController>()
                .AddTransient<ComputerController>()
                .AddTransient<ProcessesController>();        
        } 

        private static RunPropertyModel InputAdress(){
            bool  ErrorPort = false, ErrorCount = false;
            IPAddress ip;
            int port;
            int clientsCount;
            do{                
                Console.WriteLine("Input Port:");
                string portstr = Console.ReadLine();
                Console.WriteLine("Input Clients Count:");
                string countstr = Console.ReadLine();
                IPAddress.TryParse("0.0.0.0",out ip);
                ErrorPort = !int.TryParse(portstr,out port);
                ErrorCount = !int.TryParse(countstr,out clientsCount);
            }while(ErrorPort || ErrorCount);
            return new RunPropertyModel{
                IPAddress = ip,
                Port = port,
                ClientsCount = clientsCount
            };
        }  

    }
}
