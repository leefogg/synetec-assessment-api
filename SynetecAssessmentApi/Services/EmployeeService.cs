using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Contracts;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _dbContext;

        public EmployeeService(AppDbContext context)
        {
            _dbContext = context;
        }

        public Task<List<EmployeeDto>> GetAllEmployees()
        {
           var employees = _dbContext
                .Employees
                .Include(e => e.Department)
                .Select(employee => new EmployeeDto(employee))
                .ToListAsync();

            return employees;
        }

        public async Task<Employee> GetEmployee(int selectedEmployeeId)
        {
            return await _dbContext.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(item => item.Id == selectedEmployeeId);
        }

        public int GetTotalSalary()
        {
            //get the total salary budget for the company
            return _dbContext.Employees.Sum(item => item.Salary);
        }
    }
}
