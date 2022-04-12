using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace lab1.Models
{
    public class DepartmentLayer
    {
        Context_ db;
        public DepartmentLayer()
        {
            db = new Context_();
        }
        public async Task<List<Department>> getAll()
        {
            var list = await db.departments.ToListAsync();
            return list;
        }
    }
}
