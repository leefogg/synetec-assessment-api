using Microsoft.VisualStudio.TestTools.UnitTesting;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Test
{
    [TestClass]
    public class BonusServiceTests
    {
        [TestMethod]
        [DataRow(1000, 1000, 100, 100)]
        [DataRow(100, 1000, 100, 10)]
        [DataRow(1000, 100, 100, 1000)]
        [DataRow(123456, 100, 15, 18518.4)]
        public void Calculate_CorrectPercentage(
            int bonusPoolAmount, 
            int totalSalary, 
            int employeeSalary,
            double expected) 
        {
            var bonusService = new BonusPoolService();
            var actual = bonusService.Calculate(bonusPoolAmount, totalSalary, employeeSalary);
            Assert.AreEqual((decimal)expected, actual);
        }
    }
}
