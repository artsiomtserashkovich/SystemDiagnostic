using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Diagnostic.DTO.Entities;
using SystemDiagnostic.Diagnostic.Server.Services.Interfaces;
using SystemDiagnostic.Entitites.MonitoringInformation;

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
            string computerId = _unitOfWork.Computers.GetIdByLogin(computerLogin);
            foreach(ProcessDTO process in processes)
            {
                Process dbProcess = _unitOfWork.Processes.GetProcessByComputerIdAndName(computerId, process.Information.Name);
                if (dbProcess == null)
                    AddProcess(computerId, process);
                else
                    UpdateProcess(computerId, dbProcess.Id, process);
            }
            _unitOfWork.SaveChanges();
        }

        public void UpdateProcess(string computerId,string processId,ProcessDTO process)
        {
            ProcessPerfomance newProcessPerfomance = _mapper.Map<ProcessPerfomanceDTO, ProcessPerfomance>
                (process.PerfomanceInformation);
            newProcessPerfomance.CreationDate = process.Information.CreationDate;
            newProcessPerfomance.RecordDate = DateTime.Now;
            newProcessPerfomance.ProcessId = processId;
            _unitOfWork.ProcessesPerfomance.Add(newProcessPerfomance);
            _unitOfWork.SaveChanges();

            ProcessInformation dbprocessInformation = _unitOfWork.ProcessesInformation
                .GetProcessInformationByProcessId(processId);
            if (dbprocessInformation != null)
                _unitOfWork.ProcessesInformation.Remove(dbprocessInformation);
            ProcessInformation newProcessInformation = _mapper.Map<ProcessInformationDTO, ProcessInformation>
                (process.Information);
            newProcessInformation.ProcessId = processId;
            
            _unitOfWork.ProcessesInformation.Add(newProcessInformation);
            _unitOfWork.SaveChanges();
        }

        public void AddProcess(string computerId,ProcessDTO process)
        {
            Process newProcess = new Process
            {
                ComputerId = computerId,
                Name = process.Information.Name,                
            };
            _unitOfWork.Processes.Add(newProcess);
            _unitOfWork.SaveChanges();
            string processId = _unitOfWork.Processes
                .GetProcessByComputerIdAndName(computerId, process.Information.Name).Id;

            ProcessPerfomance newProcessPerfomance = _mapper.Map<ProcessPerfomanceDTO, ProcessPerfomance>
                (process.PerfomanceInformation);
            newProcessPerfomance.CreationDate = process.Information.CreationDate;
            newProcessPerfomance.ProcessId = processId;
            newProcessPerfomance.RecordDate = DateTime.Now;
            _unitOfWork.ProcessesPerfomance.Add(newProcessPerfomance);
            _unitOfWork.SaveChanges();

            ProcessInformation newProcessInformation = _mapper.Map<ProcessInformationDTO, ProcessInformation>
                (process.Information);
            newProcessInformation.ProcessId = processId;
            _unitOfWork.ProcessesInformation.Add(newProcessInformation);
            _unitOfWork.SaveChanges();
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
