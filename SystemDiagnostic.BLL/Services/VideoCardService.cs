using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.BLL.Interfaces;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.BLL.Services
{
    public class VideoCardService : IVideoCardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VideoCardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public bool DeleteVideoCardById(string id)
        {
            VideoCard videoCard = _unitOfWork.VideoCards.Get(id);
            if (videoCard == null)
                return false;
            else
            {
                _unitOfWork.VideoCards.Remove(videoCard);
                _unitOfWork.SaveChanges();
                return true;
            }
        }

        public VideoCard GetVideoCardById(string id)
        {
            return _unitOfWork.VideoCards.Get(id);
        }

        public IEnumerable<VideoCard> GetVideoCards()
        {
            return _unitOfWork.VideoCards.GetAll();
        }
    }
}
