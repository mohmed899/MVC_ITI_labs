using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//lab 5
namespace lab1.Models
{
    public class CourseLayer
    {
        Context_ db;
       public CourseLayer()
        {
            db = new Context_();    
        }
        public async  Task<List<Course>> getAll()
        {
          var courses =  await db.courses.Include(c=>c.department).Include(c=>c.instructor).ToListAsync();
            return courses;
        }

        // save new or edite old 
        public async void save(Course course)
        {
            // if already exist 
            Course OldCuorse = db.courses.SingleOrDefaultAsync(c => c.Id == course.Id).Result;
              if( OldCuorse != null )
            {
                OldCuorse.Name = course.Name;
                OldCuorse.degree = course.degree;
                OldCuorse.minDegree = course.minDegree;
                OldCuorse.dept_id = course.dept_id; 
            }
            else  // new course just save it 
                db.courses.Add(course);

                await db.SaveChangesAsync();
        }

        public async void delete(int id)

        {
            var courses = await db.courses.SingleOrDefaultAsync(c => c.Id==id);
            if( courses != null)
            {
                db.courses.Remove(courses);
               await db.SaveChangesAsync();
            }

        }
    }
}
