using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTracker.Models
{
    public class Employee
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Please Enter a Name")]
        [StringLength(60,MinimumLength =3,ErrorMessage ="Please enter a name with minimum of 3 characters.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        //[Required(ErrorMessage = "Please Enter an Email.")]
        [Display(Name = "Work Email")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Please Enter a Phone Number")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Invalid Phone Number.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        //[Required(ErrorMessage = "Please Enter your date of birth.")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        //[Required(ErrorMessage = "Please Enter your Salary")]
        [Display(Name = "Salary")]
        public Double MonthltySalary { get; set; }
        
    }
}
