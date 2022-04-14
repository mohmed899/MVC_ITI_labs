using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace lab1.Models
{
    public class DepartmentLayer : IDepartmentLayer
    {
        Context_ db;
        public DepartmentLayer(Context_ context_ )
        {
            db = context_;
        }
        public async Task<List<Department>> getAll()
        {
            var list = await db.departments.ToListAsync();
            return list;
        }

        public List<Course> getCourses(int deptId)
        {
            // var dept =  db.departments.Include(d => d.Courses).SingleOrDefault(d=>d.Id== deptId);
            return db.courses.Where(c => c.dept_id == deptId).ToList();
        }
    }
}
