using System;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.Attributes
{
    public class CRResponseHandlerAttribute : Attribute
    {
        public int Status {get;set;}
        public CRResponseHandlerAttribute(int status){
            Status = status;
        }
    }
}
