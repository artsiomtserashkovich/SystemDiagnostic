using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Queries
{
    abstract class WMIBaseQuery
    {
        private readonly SelectQuery _selectQuery;
        protected WMIBaseQuery(string className, string condition = null,Type entity = null)
        {
            string[] properties = PropertiesFormater(entity);
            _selectQuery = new SelectQuery(className, condition,properties);
        }
        
        private string[] PropertiesFormater(Type enitity){
            if(enitity == null) return null;
            List<string> properties = new List<string>();
            foreach(var property in enitity.GetProperties()){
                var wmiattribute = (WMIAttribute)Attribute.GetCustomAttribute(property,typeof(WMIAttribute));
                if(wmiattribute != null){
                    properties.Add(wmiattribute.WMIProperty);
                }
            }
            return properties.ToArray();
        }
        public SelectQuery SelectQuery => _selectQuery;
    }
}
