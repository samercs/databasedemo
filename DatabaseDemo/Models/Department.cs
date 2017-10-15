﻿using System.Collections.Generic;

namespace DatabaseDemo.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}