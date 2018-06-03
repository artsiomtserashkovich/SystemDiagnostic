using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.BLL.Interfaces
{
    public interface IVideoCardService
    {
        VideoCard GetVideoCardById(string id);
        IEnumerable<VideoCard> GetVideoCards();
        bool DeleteVideoCardById(string id);
    }
}
