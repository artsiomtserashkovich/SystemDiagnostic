using System;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities
{
    public class UIOutputModel
    {
        public string Title {get;set;}
        public bool IsArgumentsIsRequired {get;set;}
        public string OtherInformation {get;set;}
    }
}