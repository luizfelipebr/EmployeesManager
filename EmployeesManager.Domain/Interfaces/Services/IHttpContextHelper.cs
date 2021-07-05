using EmployeesManager.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Domain.Interfaces.Services
{
    public interface IHttpContextHelper
    {
        Employee GetCurrentUser();
    }
}
