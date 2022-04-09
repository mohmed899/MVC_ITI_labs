using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using lab1.viewModels;
namespace lab1.Models
{
    public class StudentLayer
    {
        Context_ db = new Context_();
        List<Student> students;
      public  StudentLayer()
        {
            students = new List<Student>();
            students.Add(new Student() { id=1,name="mohamed",address="123 st",img="1.jpg"});
            students.Add(new Student() { id = 2,name = "kaled", address = "123 st", img = "2.jpg" });
            students.Add(new Student() { id = 3,name = "Issawi", address = "123 st", img = "1.jpg" });           
        }
       public  List<Student> getAll()
        {
            return students;
        }
        public Student getStudentByID (int id )
        {
            return students.Find(s=>s.id==id);
        }

        public StudentGradViewModel getStudentgrade(int id , string crsName )
        {
            var result = db.crsResults.Include(r=>r.course).Include(r=>r.trainee).FirstOrDefault(r => r.train_id == id && r.course.Name == crsName);
            //var student = result.trainee;
            //var course = result.course;
            if ( result != null)
            {
                StudentGradViewModel stuVM = new StudentGradViewModel()
                {
                    CrsName = result.course.Name,
                    grade = result.degree,
                    StuName = result.trainee.name,
                    Mingrade = result.course.minDegree
                };
                return stuVM;
            }
            return null; 
        }

        public List<StudentGradViewModel> getStudentgrades(int id)
        {
            var result = db.crsResults.Include(r => r.course).Include(r => r.trainee).Where(r => r.train_id == id);
            //var student = result.trainee;
            //var course = result.course;
            if (result != null)
            {
                List<StudentGradViewModel> students = new List<StudentGradViewModel> ();
                foreach(var student in result)
                {
                    StudentGradViewModel stuVM = new StudentGradViewModel()
                    {
                        CrsName = student.course.Name,
                        grade = student.degree,
                        StuName = student.trainee.name,
                        Mingrade = student.course.minDegree
                    };
                    students.Add(stuVM);    
                }
                
                return students;
            }
            return null;
        }
    }
}
