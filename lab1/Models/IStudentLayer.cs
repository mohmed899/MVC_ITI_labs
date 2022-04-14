using lab1.viewModels;
using System.Collections.Generic;

namespace lab1.Models
{
    public interface IStudentLayer
    {
        List<Trainee> getAll();
        Trainee getByID(int id);
        List<StudentGradViewModel> getCoursesGrades(int id);
        StudentGradViewModel getgrade(int id, string crsName);
    }
}