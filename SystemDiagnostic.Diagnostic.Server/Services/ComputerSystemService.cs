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
            ComputerSystem _computerSystem = _unitOfWork.ComputerSystems
                .GetByComputerLogin(computerLogin);
            if(_computerSystem == null)
            {
                AddComputerSystem(computerLogin, computerSystem);
            }
            else
            {
                _computerSystem = _mapper.Map<ComputerSystemDTO, ComputerSystem>
                    (computerSystem, _computerSystem);
                _unitOfWork.ComputerSystems.Update(_computerSystem);
                _unitOfWork.SaveChanges();
            }
        }

        public void AddComputerSystem(string computerLogin,ComputerSystemDTO computerSystem)
        {
            ComputerSystem _computerSystem = _mapper.Map<ComputerSystemDTO, ComputerSystem>
                (computerSystem);
            _computerSystem.ComputerId = _unitOfWork.Computers.GetIdByLogin(computerLogin);
            _unitOfWork.ComputerSystems.Add(_computerSystem);
            _unitOfWork.SaveChanges();
        }
    }
}
