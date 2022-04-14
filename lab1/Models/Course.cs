using lab1.Models.CustomValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab1.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [Range(50,100)]
        public int degree { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "course name must be between 2-20 char")]
        [MinLength(2, ErrorMessage ="course name must be between 2-20 char")]     
        
      // [Uniqe]
         [Remote("IsValidName", "Course", ErrorMessage = "already Exist", AdditionalFields = "Id")]
        public string Name { get; set; }

        [Required]
        [Remote("IsValidMinDgree","Course",ErrorMessage = "inValid Min Degree" ,AdditionalFields = "degree")]
        [Display(Name ="Min Degree")]
        public int minDegree { get; set; }

        [ForeignKey("department")]
        [Display(Name = "Department")]
        public int dept_id { get; set; }

        //navigators
        public virtual Department department { get; set; }
        public virtual List<CrsResult> CrsResults { get; set; }
        public virtual List<Instructor> instructor  { get; set; }

    }
}
