using SynetecAssessmentApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Contracts
{
    public interface IBonusPoolService
    {
        Task<BonusPoolCalculatorResultDto> CalculateAsync(int bonusPoolAmount, int selectedEmployeeId);
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
    }
}
