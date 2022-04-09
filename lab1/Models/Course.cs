using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab1.Models
{
    public class Course
    {
        public int Id { get; set; }
        public int degree { get; set; }
        public int minDegree { get; set; }
        public string Name { get; set; }
        [ForeignKey("department")]
        public int dept_id { get; set; }

        //navigators
        public virtual Department department { get; set; }
        public virtual List<CrsResult> CrsResults { get; set; }
        public virtual List<Instructor> instructor  { get; set; }

    }
}
