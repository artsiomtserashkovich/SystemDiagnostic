using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.BLL.Interfaces;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites.MonitoringInformation;

namespace SystemDiagnostic.BLL.Services
{
    public class ProcessService : IProcessService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProcessService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public bool DeleteProcessById(string id)
        {
            throw new NotImplementedException();
        }

        public Process GetProcessById(string id)
        {
            return _unitOfWork.Processes.Get(id);
        }

        public Process GetProcessByNameAndComputerId(string name, string computerId)
        {
            return _unitOfWork.Processes.GetProcessByComputerIdAndName(computerId, name);
        }

        public IEnumerable<Process> GetProcessesByComputerId(string computerId)
        {
            return _unitOfWork.Processes.GetProcessesByComputerId(computerId);
        }
    }
}
