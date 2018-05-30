using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites;

namespace SystemDiagnostic.DAL.Interfaces
{
    public interface IComputerRepository : IRepository<Computer>
    {
        Computer GetByLogin(string login);
        IEnumerable<Computer> GetOnlineComputers();
        void ChangeConnectionStatus(string id, bool status);
    }
}
