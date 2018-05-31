using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemDiagnostic.DAL.Data;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.DAL.Repositories
{
    public class MotherBoardRepository : Repository<MotherBoard> , IMotherBoardRepository
    {
        public MotherBoardRepository(ApplicationDataBaseContext applicationDataBaseContext) 
            : base(applicationDataBaseContext) { }

        public MotherBoard GetMotherBoardByComputerId(string computerId)
        {
            return _DbSet.FirstOrDefault(c => c.ComputerId == computerId);
        }
    }
}
