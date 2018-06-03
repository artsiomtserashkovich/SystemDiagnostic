using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites.OperatingInformation;
using SystemDiagnostic.ViewModel;

namespace SystemDiagnostic.BLL.Interfaces
{
    public interface IComputerSystemService
    {
        IEnumerable<ComputerSystemViewModel> GetComputerSystems();
        ComputerSystemViewModel GetComputerSystemById(string id);
        ComputerSystemViewModel GetComputerSystemByComputerId(string computerId);
        ComputerSystemViewModel GetComputerSystemByComputerLogin(string computerLogin);
        bool DeleteComputerSystemById(string id);
    }
}
