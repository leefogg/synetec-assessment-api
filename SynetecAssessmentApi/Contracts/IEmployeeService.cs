using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Contracts
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDto>> GetAllEmployees();
        public int GetTotalSalary();
        public Task<Employee> GetEmployee(int id);
    }
}
