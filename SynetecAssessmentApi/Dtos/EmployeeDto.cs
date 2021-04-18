using SynetecAssessmentApi.Domain;

namespace SynetecAssessmentApi.Dtos
{
    public class EmployeeDto
    {
        public EmployeeDto(Employee commonModel)
        {
            Fullname = commonModel.Fullname;
            JobTitle = commonModel.JobTitle;
            Salary = commonModel.Salary;
            Department = new DepartmentDto(commonModel.Department);
        }

        public string Fullname { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public DepartmentDto Department { get; set; }
    }
}
