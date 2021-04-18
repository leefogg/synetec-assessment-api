using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Contracts;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Services
{
    public class BonusPoolService : IBonusPoolService
    {
        public decimal Calculate(int bonusPoolAmount, int totalSalary, int employeeSalary)
        {
            //calculate the bonus allocation for the employee
            var bonusPercentage = (decimal)employeeSalary / (decimal)totalSalary;
            var bonusAllocation = bonusPercentage * bonusPoolAmount;
            return bonusAllocation;
        }
    }
}
