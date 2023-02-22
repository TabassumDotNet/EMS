using System.ComponentModel.DataAnnotations;

namespace aim_sol.Models
{
    public class viewemploeeModel
    {
        [Key]
        public int EmpId { get; set; }

        [Required]
        public string EmpName { get; set; }

        [Required]
        public double? EmpSalary { get; set; }

        [Required]
        public string EmpEmail { get; set; }

        [Required]
        public string DepartmentName { get; set; }


    }
}
