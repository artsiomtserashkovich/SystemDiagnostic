using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.BLL.Interfaces
{
    public interface IMotherBoardService
    {
        MotherBoard GetMotherBoardById(string Id);
        bool DeleteMotherBoardById(string Id);
        IEnumerable<MotherBoard> GetMotherBoards();
    }
}
