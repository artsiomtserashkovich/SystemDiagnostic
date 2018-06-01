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
        private readonly IUnitOfWork _unitOfWork;

        public AuthorizeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CheckAuthorize(string computerLogin, string computerPassword)
        {
            return _unitOfWork.Computers.Auhtorize(computerLogin, computerPassword);
        }

        public bool CheckLogin(string computerLogin)
        {
            return _unitOfWork.Computers.CheckUniqueLogin(computerLogin);
        }
    }
}
