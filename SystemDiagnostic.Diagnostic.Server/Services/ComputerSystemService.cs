using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Diagnostic.DTO.Entities;
using SystemDiagnostic.Diagnostic.Server.Services.Interfaces;

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
            throw new NotImplementedException();
        }
    }
}
