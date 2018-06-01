using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Diagnostic.DTO.Entities;
using SystemDiagnostic.Diagnostic.Server.Services.Interfaces;

namespace SystemDiagnostic.Diagnostic.Server.Services
{
    class ProcessService : IProcessService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void AddProcessesPerfomance(string computerLogin, IEnumerable<ProcessPerfomanceDTO> processesPerfomance)
        {
            throw new NotImplementedException();
        }

        public void UpdateProcesses(string computerLogin, IEnumerable<ProcessDTO> processes)
        {
            throw new NotImplementedException();
        }

        public void UpdateProcessesInformation(string computerLogin, IEnumerable<ProcessInformationDTO> processesInformation)
        {
            throw new NotImplementedException();
        }

        public void UpdateProcessInformation(string computerLogin, ProcessInformationDTO processInfromation)
        {
            throw new NotImplementedException();
        }
    }
}
