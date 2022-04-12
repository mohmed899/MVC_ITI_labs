using lab1.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
namespace lab1.viewModels
{
    public class InstructorNewDataViewModel
    {
        public Instructor instructor { get; set; }
        public List<Department> departments { get; set; }
        public List<Course> courses { get; set; }
        public IFormFile? poto { get; set; }
    }
}
