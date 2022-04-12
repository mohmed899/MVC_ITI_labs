using Microsoft.AspNetCore.Mvc;
using lab1.Models;
using System.Linq;
using lab1.viewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

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
        public IActionResult Save(Instructor ins , IFormFile poto)
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



        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size });
        }
    }
}
