﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SystemDiagnostic.DAL.Interfaces
{
    public interface IProcessRepository : IRepository<Process>
    { 
        IEnumerable<Process> GetProcessesByComputerId(string computerId);
        IEnumerable<Process> GetProcessesByComputerLogin(string computerLogin);
    }
}