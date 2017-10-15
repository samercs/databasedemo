using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Resources;

namespace DatabaseDemo.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Display(Name = "الاسم")]
        [Remote("CheckName", "Students", ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "ErrorName")]
        public string Name { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال العمر")]
        public int Age { get; set; }
        public string City { get; set; }

        public int DeptId { get; set; }

        [ForeignKey("DeptId")]
        public virtual Department Dept { get; set; }


        public virtual ICollection<FKStuCourse> FkStuCourses { get; set; }


    }
}