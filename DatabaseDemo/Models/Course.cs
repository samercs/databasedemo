﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseDemo.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public decimal Prices { get; set; }

        public virtual ICollection<FKStuCourse> FkStuCourses { get; set; }

    }
}