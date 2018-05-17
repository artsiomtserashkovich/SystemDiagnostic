using System;
using System.Linq;
using System.Reflection;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Attributes;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Interfaces;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRServer
{
    public abstract class BaseServerCommandHandler : IServerCommandHandler
    {
        private Type _handleclass;

        protected BaseServerCommandHandler(Type hanldeclass)
        {
            _handleclass = hanldeclass;
        }
        public ServerResponseDTO HandleCommand(ClientCommandDTO clientCommand)
        {
            MethodInfo handleMethod = SearchHandleMethod(_handleclass, clientCommand.Command);
            if (handleMethod == null)
                throw new ServerCommandHandleException("Undefined command");
            ServerResponseInformation serverResponseInformation        
                = (ServerResponseInformation)handleMethod.Invoke(this, new object[]{
                        clientCommand.Information
                    });
            return new ServerResponseDTO
            {                
                IdCommand = clientCommand.IdCommand,
                Command = clientCommand.Command,
                Information = serverResponseInformation
            };
        }

        private MethodInfo SearchHandleMethod(Type hanldeclass, string command)
        {
            foreach (MethodInfo method in hanldeclass.GetMethods())
            {
                CRCommandHandlerAttribute attribute =
                    method.GetCustomAttributes<CRCommandHandlerAttribute>().FirstOrDefault();
                if (attribute?.Command == command)
                    return method;
            }
            return null;
        }

    }
}
