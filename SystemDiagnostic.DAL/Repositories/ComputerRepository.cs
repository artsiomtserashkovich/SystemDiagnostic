using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemDiagnostic.DAL.Data;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites;

namespace SystemDiagnostic.DAL.Repositories
{
    public class ComputerRepository : Repository<Computer> , IComputerRepository
    {
        public ComputerRepository(ApplicationDataBaseContext applicationDataBaseContext) 
            : base(applicationDataBaseContext) { }

        public bool Auhtorize(string login, string password)
        {
            return _DbSet.FirstOrDefault(c => c.Login == login && c.Password == password) == null;
        }        

        public bool CheckUniqueLogin(string login)
        {
            return _DbSet.FirstOrDefault(c => c.Login == login) == null;
        }

        public Computer GetByLogin(string login)
        {
            return _DbSet.FirstOrDefault(c => c.Login == login);
        }

        public IEnumerable<Computer> GetOnlineComputers()
        {
            return _DbSet.Where(c => c.IsConnected);
        }
    }
}
