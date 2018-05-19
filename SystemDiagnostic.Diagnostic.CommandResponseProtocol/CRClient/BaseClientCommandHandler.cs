using System;
using System.Linq;
using System.Reflection;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Attributes;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Exceptions;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient
{
    public abstract class BaseClientCommandHandler : IClientCommandHandler
    {
        private Type _classHandle;

        protected BaseClientCommandHandler(Type classHandle){
            _classHandle = classHandle;
        }
        public ClientCommandDTO HandleClientCommandRequest(ClientCommandRequest clientCommandRequest, ClientLoginModel clientLoginModel)
        {
            MethodInfo handleMethod
                = SearchHandleMethod(_classHandle, clientCommandRequest.Command);
            if (handleMethod == null)
                throw new ClientCommandHandlerException("Undefined command.");
            object clientCommand = handleMethod?.Invoke(this, new object[] { clientCommandRequest });
            if ((clientCommand is string) && !string.IsNullOrEmpty(((string)clientCommand)))
            {
                return new ClientCommandDTO(
                    new ClientCommandInformation
                    {
                        SerializedData = (string)clientCommand,
                        ClientLogin = clientLoginModel
                    },
                    clientCommandRequest.Command
                    );
            }
            else
                throw new ClientCommandHandlerException("Error while forming command.");
        }

        private MethodInfo SearchHandleMethod(Type classHandle, string command)
        {
            foreach (MethodInfo method in classHandle.GetMethods())
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
