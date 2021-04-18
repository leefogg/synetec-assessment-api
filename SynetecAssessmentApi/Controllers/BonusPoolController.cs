using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Contracts;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    public class BonusPoolController : Controller
    {
        private readonly IBonusPoolService _bonusPoolService;
        private readonly IEmployeeService _employeeService;

        public BonusPoolController(IBonusPoolService bonusPoolSerivce, IEmployeeService employeeService)
        {
            _bonusPoolService = bonusPoolSerivce;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _employeeService.GetAllEmployees());
        }

        [HttpPost]
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusDto request)
        {
            if (request.SelectedEmployeeId == 0)
                return ErrorResponse();

            var employee = await _employeeService.GetEmployee(request.SelectedEmployeeId);
            if (employee == null)
                return ErrorResponse();

            var totalSalary = _employeeService.GetTotalSalary();
            var bonusAllocation = _bonusPoolService.Calculate(request.TotalBonusPoolAmount, totalSalary, employee.Salary);

            var result = new BonusPoolCalculatorResultDto
            {
                Employee = new EmployeeDto
                {
                    Fullname = employee.Fullname,
                    JobTitle = employee.JobTitle,
                    Salary = employee.Salary,
                    Department = new DepartmentDto
                    {
                        Title = employee.Department.Title,
                        Description = employee.Department.Description
                    }
                },

                Amount = bonusAllocation
            };

            return Ok(result);
        }

        private IActionResult ErrorResponse() => StatusCode((int)HttpStatusCode.BadRequest);
    }
}
