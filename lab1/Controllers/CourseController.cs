using Microsoft.AspNetCore.Mvc;
using lab1.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Linq;

namespace lab1.Controllers
{
    public class CourseController : Controller
    {
        CourseLayer courseLayer;
        public CourseController()
        {
            courseLayer = new CourseLayer();
        }
        public async Task <IActionResult> Index()
        {           
            var list = courseLayer.getAll();
            return View(list.Result);
        }

        public IActionResult New( Course course )
        {
            DepartmentLayer departmentLayer = new DepartmentLayer();
            ViewBag.department = departmentLayer.getAll().Result;
          
            return View(course);
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save( Course course)
        {
            if (ModelState.IsValid)
            {
                courseLayer.save(course);
                return RedirectToAction("Index");

            }
            else
                return RedirectToAction("New", course);
        }

        public IActionResult Remove(int  id)
        {
            courseLayer.delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult IsValidMinDgree(int degree, int minDegree)
        {
            if( degree < minDegree)
                return Json(false);

            return Json(true);
        }


        public IActionResult IsValidName(string Name , int Id)
        {
              Context_ db = new Context_();


            // its new course 
            if( db.courses.SingleOrDefault(c => c.Id == Id)==null )
            {
              var  crs = db.courses.SingleOrDefault(c=>c.Name== Name);
                if (crs == null)
                    return Json(true);
                else
                return Json(false);
            }
            else
            {

            var crs = db.courses.SingleOrDefault(c => c.Name == Name);
            if (crs != null && crs!=db.courses.SingleOrDefault(c => c.Id == Id))
                return Json(false);
            else
                return Json(true);
            }


        }
    }
}
