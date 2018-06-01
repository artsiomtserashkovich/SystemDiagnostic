using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.DAL.Interfaces
{
    public interface IVideoCardRepository : IRepository<VideoCard>
    {
        IEnumerable<VideoCard> GetVideoCardsByComputerId(string computerId);
        IEnumerable<VideoCard> GetVideoCardsByComputerLogin(string computerLogin);
    }
}
