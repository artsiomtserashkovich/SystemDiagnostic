using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.BLL.Interfaces;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.BLL.Services
{
    public class MotherBoardService : IMotherBoardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MotherBoardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public bool DeleteMotherBoardById(string id)
        {
            MotherBoard motherBoard = _unitOfWork.MotherBoards.Get(id);
            if (motherBoard == null)
                return false;
            else
            {
                _unitOfWork.MotherBoards.Remove(motherBoard);
                _unitOfWork.SaveChanges();
                return true;
            }
        }

        public MotherBoard GetMotherBoardById(string id)
        {
            return _unitOfWork.MotherBoards.Get(id);
        }

        public IEnumerable<MotherBoard> GetMotherBoards()
        {
            return _unitOfWork.MotherBoards.GetAll();
        }
    }
}
