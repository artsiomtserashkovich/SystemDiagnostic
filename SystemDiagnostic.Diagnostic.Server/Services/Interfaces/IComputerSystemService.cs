using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Server.Services.Interfaces
{
    interface IComputerSystemService
    {
        void UpdateComputerSystem(string computerLogin, ComputerSystemDTO computerSystem);
    }
}