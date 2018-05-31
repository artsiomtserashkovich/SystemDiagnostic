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
        bool Auhtorize(string login, string password);
        bool CheckUniqueLogin(string Login);
    }
}
