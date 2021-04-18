using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Contracts;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Services;
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

        [HttpPost()]
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusDto request)
        {
            var employee = await _employeeService.GetEmployee(request.SelectedEmployeeId);
            var totalSalary = _employeeService.GetTotalSalary();
            var result = _bonusPoolService.Calculate(request.TotalBonusPoolAmount, totalSalary, employee);
            return Ok(result);
        }
    }
}
