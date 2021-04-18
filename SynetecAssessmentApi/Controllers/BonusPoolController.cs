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

        public BonusPoolController(IBonusPoolService bonusPoolSerivce)
        {
            _bonusPoolService = bonusPoolSerivce;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _bonusPoolService.GetEmployeesAsync());
        }

        [HttpPost()]
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusDto request)
        {
            return Ok(await _bonusPoolService.CalculateAsync(
                request.TotalBonusPoolAmount,
                request.SelectedEmployeeId));
        }
    }
}
