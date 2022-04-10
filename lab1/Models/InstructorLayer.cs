using System.Linq;
namespace lab1.Models
{

    public class InstructorLayer
    {   //LAB 4 
        public bool EditInstructor(int id, Instructor oldIns)
        {
            using(var db = new Context_())
            {
               var ins = db.Instructors.SingleOrDefault(i=> i.Id==id);
                if(ins != null)
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
        }
        //lab 4 
        public bool AddInstructor ( Instructor ins)
        {
            using ( var db = new Context_())
            {
                try { 
                db.Instructors.Add(ins);
                    db.SaveChanges();
                    return true;
                }
                catch {
                    return false;
                }
            }
        }

        public void remove( int id)
        {
            using ( var db = new Context_())
            {
              Instructor ins = db.Instructors.SingleOrDefault( i=> i.Id==id);
                db.Instructors.Remove(ins);
                db.SaveChanges();


            }
        }
    }
}
