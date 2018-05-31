using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemDiagnostic.DAL.Data;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.DAL.Repositories
{
    public class VideoCardRepository : Repository<VideoCard>, IVideoCardRepository
    {
        public VideoCardRepository(ApplicationDataBaseContext applicationDataBaseContext) 
            : base(applicationDataBaseContext) { }

        public IEnumerable<VideoCard> GetVideoCardsByComputerId(string computerId)
        {
            return _DbSet.Where(c => c.ComputerId == computerId);
        }
    }
}
