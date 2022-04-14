using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab1.Models
{
    public interface IDepartmentLayer
    {
        Task<List<Department>> getAll();
        List<Course> getCourses(int deptId);
    }
}