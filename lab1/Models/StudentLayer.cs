using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using lab1.viewModels;
namespace lab1.Models
{
    public class StudentLayer : IStudentLayer
    {
        Context_ db;
        public StudentLayer(Context_ context_)
        {
            db = context_;
        }

        public List<Trainee> getAll()
        {
            return db.trainees.ToList();
        }
        public Trainee getByID(int id)
        {
            return db.trainees.SingleOrDefault(T => T.Id == id);
        }

        public StudentGradViewModel getgrade(int id, string crsName)
        {
            var result = db.crsResults.Include(r => r.course).Include(r => r.trainee).FirstOrDefault(r => r.train_id == id && r.course.Name == crsName);
            if (result != null)
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

        public List<StudentGradViewModel> getCoursesGrades(int id)
        {
            var result = db.crsResults.Include(r => r.course).Include(r => r.trainee).Where(r => r.train_id == id);
            if (result != null)
            {
                List<StudentGradViewModel> students = new List<StudentGradViewModel>();
                foreach (var student in result)
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
