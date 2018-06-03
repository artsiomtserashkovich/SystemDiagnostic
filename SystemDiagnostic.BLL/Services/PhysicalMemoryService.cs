using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.BLL.Interfaces;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.BLL.Services
{
    public class PhysicalMemoryService : IPhysicalMemoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PhysicalMemoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public bool DeletePhysicalMemoryById(string id)
        {
            PhysicalMemory physicalMemory = _unitOfWork.PhysicalMemories.Get(id);
            if (physicalMemory == null)
                return false;
            else
            {
                _unitOfWork.PhysicalMemories.Remove(physicalMemory);
                _unitOfWork.SaveChanges();
                return true;
            }
        }

        public IEnumerable<PhysicalMemory> GetPhysicalMemories()
        {
            return _unitOfWork.PhysicalMemories.GetAll();
        }

        public PhysicalMemory GetPhysicalMemoryById(string id)
        {
            return _unitOfWork.PhysicalMemories.Get(id);
        }
    }
}
