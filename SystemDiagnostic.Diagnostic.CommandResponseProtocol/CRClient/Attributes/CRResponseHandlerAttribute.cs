using System;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Attributes
{
    public class CRResponseHandlerAttribute : Attribute
    {
        public int Status {get;set;}
        public CRResponseHandlerAttribute(int status){
            Status = status;
        }
    }
}
