
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aim_sol.Models
{
    public class Employee
    {

        [Key]
        public int EmpId { get; set; }
        [Required]
        public string EmpName { get; set; }
        [Required]
        public double? EmpSalary { get; set; }
        [Required]
        public string EmpEmail { get; set; }
        //1 to many  relation
    
       public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
       
    }


    }

