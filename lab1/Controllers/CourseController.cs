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
        ICourseLayer courseLayer;
        IDepartmentLayer departmentLayer;
        public CourseController(ICourseLayer course, IDepartmentLayer department)
        {
            courseLayer = course;
            departmentLayer = department;
        }
        public IActionResult Index()
        {           
            var list = courseLayer.getAll();
            return View(list.Result);
        }

        public IActionResult New( Course course )
        {
            ViewBag.department = departmentLayer.getAll().Result;          
            return View(course);
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Course course)
        {
            if (ModelState.IsValid)
            {
                courseLayer.save(course);
                return RedirectToAction("Index");

            }
            else
             return RedirectToAction("New", course);
            //{
             
            //    ViewBag.department = departmentLayer.getAll().Result;
            //    return PartialView("EditModle", course);
            //}
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
            if( courseLayer.getByID(Id)==null )
            {
              var  crs = courseLayer.getByName(Name);
                if (crs == null)
                    return Json(true);
                else
                return Json(false);
            }
            else
            {

            var crs = courseLayer.getByName(Name);
            if (crs != null && crs != courseLayer.getByID(Id))
                return Json(false);
            else
                return Json(true);
            }


        }

        public IActionResult EditCourseModel (int id)
        {
            ViewBag.department = departmentLayer.getAll().Result;
            return PartialView("EditModle",  courseLayer.getByID(id));
        }

        public IActionResult GetCoursDetailsPV(int id)
        {
           
            return PartialView("_CourseDetails", courseLayer.getByID(id));
        }

    }
}
