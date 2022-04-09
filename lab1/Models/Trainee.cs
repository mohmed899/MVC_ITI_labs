using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab1.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string img { get; set; }
        public string address { get; set; }
        public int grade { get; set; }
        [ForeignKey("department")]
        public int dept_id { get; set; }
        //navigators
        public virtual Department department { get; set; }
        public virtual List<CrsResult> CrsResults { get; set; }

    }
}
