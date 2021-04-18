using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Contracts
{
    public interface IBonusPoolService
    {
        int Calculate(int bonusPoolAmount, int totalSalary, int employeeSalary);
    }
}
