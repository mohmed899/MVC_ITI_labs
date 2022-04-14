using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace lab1.Models
{

    public class InstructorLayer : IInstructorLayer
    {
        Context_ db;
        public InstructorLayer(Context_ context_)
        {
            db = context_;
        }


        //LAB 4 
        public bool EditInstructor(int id, Instructor oldIns)
        {
            var ins = db.Instructors.SingleOrDefault(i => i.Id == id);
            if (ins != null)
            {
                ins.address = oldIns.address;
                ins.Name = oldIns.Name;
                ins.img = oldIns.img;
                ins.crs_id = oldIns.crs_id;
                ins.dept_id = oldIns.dept_id;
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        //lab 4 
        public bool AddInstructor(Instructor ins)
        {

            try
            {
                db.Instructors.Add(ins);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public void remove(int id)
        {

            Instructor ins = db.Instructors.SingleOrDefault(i => i.Id == id);
            db.Instructors.Remove(ins);
            db.SaveChanges();
        }

        public List<Instructor> getAll()
        {
          return  db.Instructors.Include(ins => ins.department).ToList();
        }

        public Instructor getbyID(int id)
        {
             return db.Instructors.Include(ins=>ins.department).Include(ins=>ins.course).FirstOrDefault(ins=>ins.Id==id);

        }
    }
}
