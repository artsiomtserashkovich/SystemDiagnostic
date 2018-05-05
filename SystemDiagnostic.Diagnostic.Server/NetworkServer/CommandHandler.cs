

using System;
using System.Linq;
using System.Reflection;
using SystemDiagnostic.Diagnostic.DTO.CommandHandlerEntities;
using SystemDiagnostic.Diagnostic.Server.NetworkServer.Attribute;

namespace SystemDiagnostic.Diagnostic.Server.NetworkServer{
    public class CommandHandler
    {
        private IServiceProvider serviceProvider {get;}
        public CommandHandler(IServiceProvider service){
            serviceProvider = service;
        }
        public ServerResponse RecieveClientCommand(ClientInformation clientInformation, ClientCommand clientCommand)
        {
            Type controllerClass = typeof(CommandHandler);
            object[] arguments = new object[]{
                clientInformation,
                clientCommand
            };
            return (ServerResponse)GetMethodByCommand(controllerClass,
                clientCommand.Command).Invoke(controllerClass,arguments);            
        }

        private MethodInfo GetMethodByCommand(Type controllerClass,string command){
            MethodInfo methodInfo =controllerClass.GetMethods()
                .Where(m => ((NetworkAttribute)m.GetCustomAttributes(typeof(NetworkAttribute),false)
                .FirstOrDefault())?.Command == command).FirstOrDefault();
            if(methodInfo == null)
                throw new Exception($"Cant find handler of {command} command");
            return methodInfo; 
        }

        public void RecieveClientResponse(ClientInformation clientInformation, ClientResponse clientResponse){
            throw new NotImplementedException();
        }

        [Network("Test")]
        private ServerResponse TestController(ClientInformation clientInformation,ClientCommand clientCommand){
            Console.WriteLine(clientCommand.Command);
            Console.WriteLine(clientCommand.Arguments);
            Console.WriteLine(clientInformation.IpAddress.ToString());
            return new ServerResponse{
                Arguments = " Hellow",
                Status = 200,
                Command = clientCommand.Command
            };
        } 
        
    }
}