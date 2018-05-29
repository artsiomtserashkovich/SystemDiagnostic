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
    public abstract class BaseClientResponseHandler : IClientResponseHandler
    {
        protected IClientMediator _clientMediator;
        private Type _classHandlers;

        protected BaseClientResponseHandler(Type classHandlers){
            _classHandlers = classHandlers;
        }
        public void HandleServerResponse(ServerResponseDTO serverResponse)
        {
            MethodInfo handleMethod = SearchHandlerMethod(_classHandlers,serverResponse.Information.Status);
            if(handleMethod == null)
                throw new ClientResponseHandlerException("Undefined status code of response.");
            object[] methodArguments = new object[]{serverResponse.Information,serverResponse.Command};
            handleMethod.Invoke(this,methodArguments);
        }
        
        //Private or protected?
        private MethodInfo SearchHandlerMethod(Type classHandlers, int Status)
        {
            foreach(MethodInfo methods in classHandlers.GetMethods()){
                CRResponseHandlerAttribute attribute 
                    =methods.GetCustomAttributes<CRResponseHandlerAttribute>().FirstOrDefault();
                if(attribute?.Status == Status)
                    return methods;
            }
            return null;
        }

        public void SetClientMediator(IClientMediator clientMediator)
        {
            _clientMediator = clientMediator;
        }
    }
}
