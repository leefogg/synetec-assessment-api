using SynetecAssessmentApi.Domain;

namespace SynetecAssessmentApi.Dtos
{
    public class DepartmentDto
    {
        public DepartmentDto(Department commonModel)
        {
            Title = commonModel.Title;
            Description = commonModel.Description;
        }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
