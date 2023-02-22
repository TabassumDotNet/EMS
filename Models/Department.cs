using System.ComponentModel.DataAnnotations;

namespace aim_sol.Models
{
    public class Department
    {
        [Key]
           public int DepartmentId { get; set; }
          [Required]

            public string DepartmentName { get; set; }

        public virtual List<Employee> Employees { get; set; }

    }
}
