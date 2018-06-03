using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.BLL.Interfaces;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites.OperatingInformation;
using SystemDiagnostic.ViewModel;

namespace SystemDiagnostic.BLL.Services
{
    public class ComputerSystemService : IComputerSystemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ComputerSystemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public bool DeleteComputerSystemById(string id)
        {
            ComputerSystem computer = _unitOfWork.ComputerSystems.Get(id);
            if (computer == null)
                return false;
            else
            {
                _unitOfWork.ComputerSystems.Remove(computer);
                _unitOfWork.SaveChanges();
                return true;
            }
        }

        public ComputerSystemViewModel GetComputerSystemByComputerId(string computerId)
        {
            return _mapper.Map<ComputerSystem,ComputerSystemViewModel>
                (_unitOfWork.ComputerSystems.GetByComputerId(computerId));
        }

        public ComputerSystemViewModel GetComputerSystemByComputerLogin(string computerLogin)
        {
            return _mapper.Map<ComputerSystem, ComputerSystemViewModel>
               (_unitOfWork.ComputerSystems.GetByComputerLogin(computerLogin));
        }

        public ComputerSystemViewModel GetComputerSystemById(string id)
        {
            return _mapper.Map<ComputerSystem, ComputerSystemViewModel>
               (_unitOfWork.ComputerSystems.Get(id));
        }

        public IEnumerable<ComputerSystemViewModel> GetComputerSystems()
        {
            return _mapper.Map<IEnumerable<ComputerSystem>, IEnumerable<ComputerSystemViewModel>>
                (_unitOfWork.ComputerSystems.GetAll());
        }
    }
}
