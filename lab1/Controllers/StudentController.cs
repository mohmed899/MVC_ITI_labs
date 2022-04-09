using Microsoft.AspNetCore.Mvc;
using lab1.Models;
using lab1.viewModels;
namespace lab1.Controllers
{
    public class StudentController : Controller
    {
        StudentLayer db = new StudentLayer();
       public StudentController()
        {
            db = new StudentLayer();
        }
        public IActionResult Index()
        {
            object[] arr = new object[]
            {
                 db.getAll(),
                 db.getStudentByID(1)
            };
            return View("student",arr);
        }

        public IActionResult details(int id )
        {
            return View("details", db.getStudentByID(id));
        }

        public IActionResult studentGrade(int id, string name)
        {
            StudentGradViewModel student = new StudentGradViewModel();
            return View(db.getStudentgrade(id , name));
        }

        public IActionResult studentGrades(int id)
        {
         
            return View(db.getStudentgrades(id));
        }

    }
}
