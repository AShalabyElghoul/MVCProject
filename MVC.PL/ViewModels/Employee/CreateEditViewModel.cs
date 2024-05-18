using MVC.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC.PL.ViewModels.Employee
{
    public class CreateEditViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Max Length Of Name Is 50")]
        [MinLength(5, ErrorMessage = "Min Length Of Name Is 5")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public Gender? Gender { get; set; }
        [DisplayName("Employee Type")]
        public EmpType EmployeeType { get; set; }
 
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        [Range(22, 60)]
        public int Age { get; set; }

        public int? Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$"
            , ErrorMessage = "Address Must Be Like 123-Street-City-Country")]
        public string? Address { get; set; }
        [DisplayName("Hiring Date")]
        public DateOnly HiringDate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        public IFormFile? image { get; set; }
    }
}
