using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.BLL.Interfaces;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.BLL.Services
{
    public class DiskDriveService :IDiskDriveService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiskDriveService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public bool DeleteDiskDriveById(string id)
        {
            DiskDrive diskDrive = _unitOfWork.DiskDrives.Get(id);
            if (diskDrive == null)
                return false;
            else
            {
                _unitOfWork.DiskDrives.Remove(diskDrive);
                _unitOfWork.SaveChanges();
                return true;
            }            
        }

        public DiskDrive GetDiskDriveById(string id)
        {
            return _unitOfWork.DiskDrives.Get(id);
        }

        public IEnumerable<DiskDrive> GetDiskDrives()
        {
            return _unitOfWork.DiskDrives.GetAll();
        }
    }
}
