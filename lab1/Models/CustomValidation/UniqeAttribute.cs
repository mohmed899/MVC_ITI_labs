using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace lab1.Models.CustomValidation
{
    public class UniqeAttribute : ValidationAttribute
    {
       
        //public override bool IsValid(object value)
        //{
        //    string coursName = value as string;
        //    using( var db = new Context_())
        //    {
        //        if (db.courses.SingleOrDefault(c => c.Name == coursName) == null)
        //            return true;
        //    }
        //    return false;
        //}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string coursName = value as string;

            Course OldCourse = validationContext.ObjectInstance as Course;

            
            using (var db = new Context_())
            {
                // if the course not exist  
                if (db.courses.SingleOrDefault(c => c.Id == OldCourse.Id) == null)
                {
                    if (db.courses.SingleOrDefault(c => c.Name == coursName) == null)
                        return ValidationResult.Success;
                    else
                        return new ValidationResult("Already exixt ");
                }
                else
                {
                    if (db.courses.SingleOrDefault(c => c.Name == coursName) != null && db.courses.SingleOrDefault(c => c.Name == coursName).Name!= coursName)
                        return new ValidationResult("Already exixt ");
                    else
                        return ValidationResult.Success;
                }
            }
               

            //  return base.IsValid(value, validationContext);
        }
    }
}
