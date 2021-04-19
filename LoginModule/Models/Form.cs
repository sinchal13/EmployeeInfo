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

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public int EmpId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public string FathersName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string MothersName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string address { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public double salary { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public Boolean Fresher { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Role { get; set; }
       
        public string Notes { get; set; }

    }


}

