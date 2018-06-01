using System;
using AutoMapper;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SystemDiagnostic.DAL;
using SystemDiagnostic.DAL.Data;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRServer.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRServer.Interfaces;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Interfaces;
using SystemDiagnostic.Diagnostic.Server.Controllers;
using SystemDiagnostic.Diagnostic.Server.NetworkServer;
using SystemDiagnostic.Diagnostic.Server.Services;
using SystemDiagnostic.Diagnostic.Server.Services.Interfaces;

namespace SystemDiagnostic.Diagnostic.Server
{
    public class Program
    {
        public static void Main()
        {
            ServiceCollection service = new ServiceCollection();
            ConfigureServices(service);
            ServiceProvider serviceProvider = service.BuildServiceProvider();
            IServerCommandHandler serverCommandHandler = new ServerCommandHandler(serviceProvider);
            IServer server = new CommandResponseProtocol.CRServer.Server(serverCommandHandler);
            RunPropertyModel runPropertyModel = InputAdress();
            server.Run(runPropertyModel);
        }

        private static void ConfigureServices(IServiceCollection service)
        {
            string connection = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SystemDiagnostic;Integrated Security=True";
            service
                .AddDbContext<ApplicationDataBaseContext>(options => options.UseSqlServer(connection))
                .AddTransient<IUnitOfWork,UnitOfWork>()
                .AddTransient<IAuthorizeService,AuthorizeService>()
                .AddTransient<IComputerSystemService,ComputerSystemService>()
                .AddTransient<IComputerComponentService,ComputerComponentService>()
                .AddTransient<IProcessService,ProcessService>()
                .AddTransient<AuthorizeController>()
                .AddTransient<ComputerController>()
                .AddTransient<TestController>()
                .AddTransient<ProcessesController>()
                .AddAutoMapper()
                ;
        }

        private static RunPropertyModel InputAdress()
        {
            bool ErrorPort = false, ErrorCount = false;
            IPAddress ip;
            int port;
            int clientsCount;
            do
            {
                Console.WriteLine("Input Port:");
                string portstr = Console.ReadLine();
                Console.WriteLine("Input Clients Count:");
                string countstr = Console.ReadLine();
                IPAddress.TryParse("0.0.0.0", out ip);
                ErrorPort = !int.TryParse(portstr, out port);
                ErrorCount = !int.TryParse(countstr, out clientsCount);
            } while (ErrorPort || ErrorCount);
            return new RunPropertyModel
            {
                IPAddress = ip,
                Port = port,
                ClientsCount = clientsCount
            };
        }

    }
}
