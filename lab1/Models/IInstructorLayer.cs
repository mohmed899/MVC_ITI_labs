using System.Collections.Generic;

namespace lab1.Models
{
    public interface IInstructorLayer
    {
        bool AddInstructor(Instructor ins);
        bool EditInstructor(int id, Instructor oldIns);
        void remove(int id);
        List<Instructor> getAll();
        Instructor getbyID(int id);
    }
}