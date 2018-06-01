using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Diagnostic.Server.Services.Interfaces;

namespace SystemDiagnostic.Diagnostic.Server.Services
{
    class AuthorizeService : IAuthorizeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorizeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public bool CheckAuthorize(string computerLogin, string computerPassword)
        {
            throw new NotImplementedException();
        }

        public bool CheckLogin(string computerLogin)
        {
            throw new NotImplementedException();
        }
    }
}
