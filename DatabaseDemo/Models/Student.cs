using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using DatabaseDemo.Core;
using Resources;

namespace DatabaseDemo.Models
{
    public partial class Student: IValidatableObject
    {
        public int Id { get; set; }
        [DisplayName("الاسم")]
        [WorkCount(4)]
        [Remote("CheckName", "Students", ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "ErrorName")]
        public string Name { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال العمر")]
        public int Age { get; set; }
        public string City { get; set; }

        public int DeptId { get; set; }

        [ForeignKey("DeptId")]
        public virtual Department Dept { get; set; }


        public virtual ICollection<FKStuCourse> FkStuCourses { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DeptId == 1 && Age < 20)
            {
                yield return new ValidationResult("This student must have age more than 20 years.");
            }
        }
    }
}