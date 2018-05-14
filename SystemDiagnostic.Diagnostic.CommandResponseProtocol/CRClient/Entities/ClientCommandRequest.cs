namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities
{
    public class ClientCommandRequest
    {
        public string Command {get;set;}
        public object Arguments  {get;set;}
    }
}