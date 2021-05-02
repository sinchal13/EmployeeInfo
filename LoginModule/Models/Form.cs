using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginModule.Models
{
    public class Form
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Employee ID  is required")]
        public int EmpId { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        
        [DataType(DataType.Date)]
        [Display(Name ="Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Father's Name is required")]
        [Display(Name ="Father's Name")]

        public string FathersName { get; set; }
        [Required(ErrorMessage = "Mother's Name is required")]
        [Display(Name = "Mother's Name")]
        public string MothersName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [Display(Name ="Address")]
        public string address { get; set; }
        [Required(ErrorMessage = "Salary must be a number")]
        [Display(Name ="Salary")]

        public double salary { get; set; }
        [Required(ErrorMessage = "Fresher Detail is required")]

        public Boolean Fresher { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }
       
        public string Notes { get; set; }

    }


}

