using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Diagnostic.DTO.Entities;
using SystemDiagnostic.Diagnostic.Server.Services.Interfaces;
using SystemDiagnostic.Entitites.OperatingInformation;

namespace SystemDiagnostic.Diagnostic.Server.Services
{
    class ComputerSystemService : IComputerSystemService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ComputerSystemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void UpdateComputerSystem(string computerLogin, ComputerSystemDTO computerSystem)
        {
            ComputerSystem oldComputerSystem = _unitOfWork.ComputerSystems
                .GetByComputerLogin(computerLogin);
            if (oldComputerSystem != null)
                _unitOfWork.ComputerSystems.Remove(oldComputerSystem);
            ComputerSystem newComputerSystem = _mapper.Map<ComputerSystemDTO, ComputerSystem>
                    (computerSystem);
            newComputerSystem.ComputerId = _unitOfWork.Computers.GetIdByLogin(computerLogin);
            _unitOfWork.ComputerSystems.Update(newComputerSystem);
            _unitOfWork.SaveChanges();            
        }
    }
}
