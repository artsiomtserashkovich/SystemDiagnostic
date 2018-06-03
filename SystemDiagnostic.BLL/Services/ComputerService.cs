using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemDiagnostic.BLL.Interfaces;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites;
using SystemDiagnostic.Entitites.ComputerComponents;
using SystemDiagnostic.Entitites.MonitoringInformation;
using SystemDiagnostic.Entitites.OperatingInformation;
using SystemDiagnostic.ViewModel;

namespace SystemDiagnostic.BLL.Services
{ 
    public class ComputerService : IComputerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ComputerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public bool CheckUniqueLogin(string login)
        {
            return _unitOfWork.Computers.CheckUniqueLogin(login);
        }

        public bool DeleteComputerById(string id)
        {
            Computer computer = _unitOfWork.Computers.Get(id);
            if (computer == null)
                return false;
            else
            {
                _unitOfWork.Computers.Remove(computer);
                _unitOfWork.SaveChanges();
                return true;
            }
        }

        public IEnumerable<ComputerViewModel> GetAllComputers()
        {
            IEnumerable<Computer> computers =_unitOfWork.Computers.GetAll();
            IList<ComputerViewModel> viewComputers = new List<ComputerViewModel>();
            foreach(Computer computer in computers)
            {
                ComputerViewModel computerViewModel = _mapper.Map<Computer, ComputerViewModel>(computer);
                computerViewModel.ComputerSystem = _mapper.Map<ComputerSystem, ComputerSystemViewModel>
                    (_unitOfWork.ComputerSystems.GetByComputerId(computer.Id));
                computerViewModel.MotherBoardId = _unitOfWork.MotherBoards.GetMotherBoardByComputerId(computer.Id)?.Id;
                computerViewModel.ProcessorId = _unitOfWork.Processors.GetProcessorByComputerId(computer.Id)?.Id;
                computerViewModel.DiskDrivesId = _unitOfWork.DiskDrives.GetDiskDrivesByComputerId(computer.Id)?.Select(d => d.Id);
                computerViewModel.PhysicalMemoriesId = _unitOfWork.PhysicalMemories.GetPhysicalMemoriesByComputerId(computer.Id)?.Select(d => d.Id);
                computerViewModel.VideoCardsId = _unitOfWork.VideoCards.GetVideoCardsByComputerId(computer.Id)?.Select(d => d.Id);
                computerViewModel.ProcessesId = _unitOfWork.Processes.GetProcessesByComputerId(computer.Id)?.Select(d => d.Id);
                viewComputers.Add(computerViewModel);
            }
            return viewComputers;           
        }

        public ComputerViewModel GetComputerById(string id)
        {
            Computer computer = _unitOfWork.Computers.Get(id);
            if (computer == null)
                return null;
            ComputerViewModel computerViewModel = _mapper.Map<Computer, ComputerViewModel>(computer);
            computerViewModel.ComputerSystem = _mapper.Map<ComputerSystem, ComputerSystemViewModel>
                (_unitOfWork.ComputerSystems.GetByComputerId(computer.Id));
            computerViewModel.MotherBoardId = _unitOfWork.MotherBoards.GetMotherBoardByComputerId(computer.Id)?.Id;
            computerViewModel.ProcessorId = _unitOfWork.Processors.GetProcessorByComputerId(computer.Id)?.Id;
            computerViewModel.DiskDrivesId = _unitOfWork.DiskDrives.GetDiskDrivesByComputerId(computer.Id)?.Select(d => d.Id);
            computerViewModel.PhysicalMemoriesId = _unitOfWork.PhysicalMemories.GetPhysicalMemoriesByComputerId(computer.Id)?.Select(d => d.Id);
            computerViewModel.VideoCardsId = _unitOfWork.VideoCards.GetVideoCardsByComputerId(computer.Id)?.Select(d => d.Id);
            computerViewModel.ProcessesId = _unitOfWork.Processes.GetProcessesByComputerId(computer.Id)?.Select(d => d.Id);
            return computerViewModel;
        }

        public ComputerViewModel GetComputerByLogin(string login)
        {
            Computer computer = _unitOfWork.Computers.GetByLogin(login);
            if (computer == null)
                return null;
            ComputerViewModel computerViewModel = _mapper.Map<Computer, ComputerViewModel>(computer);
            computerViewModel.ComputerSystem = _mapper.Map<ComputerSystem, ComputerSystemViewModel>
                (_unitOfWork.ComputerSystems.GetByComputerId(computer.Id));
            computerViewModel.MotherBoardId = _unitOfWork.MotherBoards.GetMotherBoardByComputerId(computer.Id)?.Id;
            computerViewModel.ProcessorId = _unitOfWork.Processors.GetProcessorByComputerId(computer.Id)?.Id;
            computerViewModel.DiskDrivesId = _unitOfWork.DiskDrives.GetDiskDrivesByComputerId(computer.Id)?.Select(d => d.Id);
            computerViewModel.PhysicalMemoriesId = _unitOfWork.PhysicalMemories.GetPhysicalMemoriesByComputerId(computer.Id)?.Select(d => d.Id);
            computerViewModel.VideoCardsId = _unitOfWork.VideoCards.GetVideoCardsByComputerId(computer.Id)?.Select(d => d.Id);
            computerViewModel.ProcessesId = _unitOfWork.Processes.GetProcessesByComputerId(computer.Id)?.Select(d => d.Id);
            return computerViewModel;

        }

        public ComputerViewModel RegisterNewComputer(string login, string password)
        {
            Computer computer =  _unitOfWork.Computers.Add(new Computer
            {
                Login = login,
                Password = password
            });
            _unitOfWork.SaveChanges();
            return _mapper.Map<Computer,ComputerViewModel>(computer);
        }
    }
}
