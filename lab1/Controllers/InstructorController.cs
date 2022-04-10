using Microsoft.AspNetCore.Mvc;
using lab1.Models;
using System.Linq;
using lab1.viewModels;
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
        //lab 4
        public IActionResult New(int id )
        {
            Instructor ins;
            //id =0 for add new ins 
            if (id == 0)
                ins = new Instructor();
            else // we just want to edit old one 
                ins = db.Instructors.SingleOrDefault(i => i.Id == id);

            InstructorNewDataViewModel Insvm= new InstructorNewDataViewModel()
            {
                instructor = ins,
                courses = db.courses.ToList(),
                departments = db.departments.ToList()
            };

            return View(Insvm);
        }

        //LAB 4 
        public IActionResult Save(Instructor ins )
        {
                InstructorLayer instructorLayer = new InstructorLayer();
            if ( ins.Id ==0)
            {
                bool succes = instructorLayer.AddInstructor(ins);
                if (succes)
                    return RedirectToAction("Index");
                else
                    return Content("error happen ");
            }
            else
            {
                bool succes = instructorLayer.EditInstructor(ins.Id, ins);
                if (succes)
                    return RedirectToAction("Index");
                else
                    return Content("error happen ");

            }
            
        }


        public IActionResult Edit()
        {
            InstructorNewDataViewModel Insvm = new InstructorNewDataViewModel()
            {
                instructor = new Instructor(),
                courses = db.courses.ToList(),
                departments = db.departments.ToList()
            };

            return View(Insvm);
        }

        public IActionResult Remove(int id)
        {
            InstructorLayer instructorLayer = new InstructorLayer();
            instructorLayer.remove(id);
            return RedirectToAction("Index");

        }
    }
}
