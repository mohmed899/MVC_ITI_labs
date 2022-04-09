using System.ComponentModel.DataAnnotations.Schema;

namespace lab1.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string img { get; set; }
        public string address { get; set;}
        [ForeignKey("department")]
        public int dept_id { get; set; }
        [ForeignKey("course")]
        public int crs_id { get; set; }

        //navigators 

        public virtual Department department { get; set; }
        public virtual Course course { get; set; }

    }
}
