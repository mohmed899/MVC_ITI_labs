using Microsoft.AspNetCore.Mvc;
using lab1.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace lab1.Controllers
{
    public class InstructorController : Controller
    {
        Context_ db;
        public InstructorController()
        {
            db = new Context_();
        }
        public IActionResult Index()
        {
            var l = db.Instructors.Include(ins => ins.department).ToList();
            
            return View( l);
        }

        public IActionResult details(int id )
        {
            var l = db.Instructors.Include(ins=>ins.department).Include(ins=>ins.course).FirstOrDefault(ins=>ins.Id==id);
            return View(l);
        }
    }
}
