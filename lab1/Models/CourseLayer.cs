using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
//lab 5
namespace lab1.Models
{
    public class CourseLayer : ICourseLayer
    {
        Context_ db;
        public CourseLayer(Context_ context_)
        {
            db = context_;
        }
        public async Task<List<Course>> getAll()
        {
            var courses = await db.courses.Include(c => c.department).Include(c => c.instructor).ToListAsync();
            return courses;
        }

        // save new or edite old 
        public  void save(Course course)
        {
            // if already exist 
            Course OldCuorse = db.courses.SingleOrDefaultAsync(c => c.Id == course.Id).Result;
            if (OldCuorse != null)
            {
                OldCuorse.Name = course.Name;
                OldCuorse.degree = course.degree;
                OldCuorse.minDegree = course.minDegree;
                OldCuorse.dept_id = course.dept_id;
            }
            else  // new course just save it 
                db.courses.Add(course);

             db.SaveChanges();
        }

        public async void delete(int id)

        {
            var courses = await db.courses.SingleOrDefaultAsync(c => c.Id == id);
            if (courses != null)
            {
                db.courses.Remove(courses);
                await db.SaveChangesAsync();
            }

        }

        public Course getByID(int id)

        {
            var course = db.courses.Include(c => c.department).SingleOrDefault(c => c.Id == id);
            return course;

        }

        public Course getByName(string name)
        {
            return db.courses.SingleOrDefault(c => c.Name == name);
        }
    }
}
