using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.BLL.Interfaces;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.BLL.Services
{
    public class ProcessorService : IProcessorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProcessorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public bool DeleteProcessorById(string id)
        {
            Processor processor = _unitOfWork.Processors.Get(id);
            if (processor == null)
                return false;
            else
            {
                _unitOfWork.Processors.Remove(processor);
                _unitOfWork.SaveChanges();
                return true;
            }
        }

        public Processor GetProcessorById(string id)
        {
            return _unitOfWork.Processors.Get(id);
        }

        public IEnumerable<Processor> GetProcessors()
        {
            return _unitOfWork.Processors.GetAll();
        }
    }
}
