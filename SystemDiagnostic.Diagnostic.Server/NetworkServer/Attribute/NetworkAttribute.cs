using System;

namespace SystemDiagnostic.Diagnostic.Server.NetworkServer.Attribute
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NetworkAttribute : System.Attribute
    {
        public string Command {get;}
        public NetworkAttribute(string command){
            Command = command;
        }
    }
}
