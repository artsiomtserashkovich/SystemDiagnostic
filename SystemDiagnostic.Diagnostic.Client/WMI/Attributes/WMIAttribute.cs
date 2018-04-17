using System;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes.Properties;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class WMIAttribute:Attribute
    {
        public WMIAttribute(string property){
            WMIProperty = property;
        }
        public string WMIProperty {get;}
    }
}
