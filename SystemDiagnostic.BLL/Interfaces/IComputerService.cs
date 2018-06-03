using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites;
using SystemDiagnostic.ViewModel;

namespace SystemDiagnostic.BLL.Interfaces
{
    public interface IComputerService
    {
        bool CheckUniqueLogin(string login);
        IEnumerable<ComputerViewModel> GetAllComputers();
        ComputerViewModel GetComputerById(string id);
        ComputerViewModel GetComputerByLogin(string login);
        ComputerViewModel RegisterNewComputer(string login, string password);
        bool DeleteComputerById(string id);
    }
}
