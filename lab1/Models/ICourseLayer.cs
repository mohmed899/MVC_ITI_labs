using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab1.Models
{
    public interface ICourseLayer
    {
        void delete(int id);
        Task<List<Course>> getAll();
        Course getByID(int id);
        Course getByName(string name);
        void save(Course course);

    }
}