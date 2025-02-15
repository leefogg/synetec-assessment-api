﻿using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Contracts;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/v1/[controller]")]
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
            if (request == null || request.SelectedEmployeeId == 0)
                return ErrorResponse();

            var employee = await _employeeService.GetEmployee(request.SelectedEmployeeId);
            if (employee == null)
                return ErrorResponse();

            var totalSalary = _employeeService.GetTotalSalary();
            var bonusAllocation = _bonusPoolService.Calculate(request.TotalBonusPoolAmount, totalSalary, employee.Salary);

            var result = new BonusPoolCalculatorResultDto
            {
                Employee = new EmployeeDto(employee),
                Amount = bonusAllocation
            };

            return Ok(result);
        }

        private IActionResult ErrorResponse() => StatusCode((int)HttpStatusCode.BadRequest);
    }
}
