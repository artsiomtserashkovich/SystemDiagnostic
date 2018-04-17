using System;
using System.Management;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Managers
{
    internal static class WMIMapper<TEntity> where TEntity : class , new()
    {
        public static TEntity Extract(ManagementBaseObject managementBaseObject){
             var result = new TEntity();
            foreach (var property in typeof(TEntity).GetProperties())
            {
                var wmiAttribute = (WMIAttribute)Attribute.GetCustomAttribute(property, typeof(WMIAttribute));
                if (wmiAttribute != null)
                {
                    var sourceValue = managementBaseObject.Properties[wmiAttribute.WMIProperty].Value;
                    var targetType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    object targetValue;
                    if (sourceValue == null)
                    {
                        targetValue = null;
                    }
                    else if (targetType == typeof(DateTime))
                    {
                        targetValue = ManagementDateTimeConverter.ToDateTime(sourceValue.ToString()).ToUniversalTime();
                    }
                    else if (targetType == typeof(Guid))
                    {
                        targetValue = Guid.Parse(sourceValue.ToString());
                    }
                    else
                    {
                        targetValue = Convert.ChangeType(
                            managementBaseObject.Properties[wmiAttribute.WMIProperty].Value, targetType);
                    }
                    property.SetValue(result, targetValue);
                }
            }
            return result;
        }
    }
}
