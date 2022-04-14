using Microsoft.AspNetCore.Mvc;
using lab1.Models;
using lab1.viewModels;
namespace lab1.Controllers
{
    public class StudentController : Controller
    {
        IStudentLayer StudentLayer;
       public StudentController( IStudentLayer student)
        {
            StudentLayer = student;
        }
        public IActionResult Index()
        {
            
            return View("student",StudentLayer.getAll());
        }

        public IActionResult details(int id )
        {
            return View("details", StudentLayer.getByID(id));
        }

        public IActionResult studentGrade(int id, string name)
        {
            return View(StudentLayer.getgrade(id , name));
        }

        public IActionResult studentGrades(int id)
        {
         
            return View(StudentLayer.getCoursesGrades(id));
        }

    }
}
