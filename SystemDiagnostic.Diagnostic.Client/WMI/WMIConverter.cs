using System;
using System.Collections;
using System.Collections.Generic;

namespace SystemDiagnostic.Diagnostic.Client.WMI
{

    public enum Architecture{
        x86 = 0,
        MIPS = 1,
        Alpha = 2,
        PowerPC = 3,
        ARM = 5,
        ia64 = 6,
        x64 = 9,
        Other
    }

    public static class WMIConverter
    {
        public static string ConvertArchitecture(int index){
             if (Enum.IsDefined(typeof(Architecture), index)) return ((Architecture)index).ToString();
            return Architecture.Other.ToString();           
        }

        public static double ConvertFromBytestoMB(ulong bytessize){
            return ((double)bytessize) / 1048576;
        }

        public static double ConvertFromBytestoGB(ulong bytessize){
            return ((double)bytessize) / 1073741824;
        }
    }
}
