using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DatabaseDemo.Models
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
            
        }

        public IDbSet<Student> Students { get; set; }
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<decimal>().Configure(prop => prop.HasPrecision(18, 3));
            //modelBuilder.Entity<FKStuCourse>()
            //    .HasRequired(i => i.Student)
            //    .WithOptional(i => i.FkStuCourse);

            //modelBuilder.Entity<FKStuCourse>()
            //    .HasRequired(i => i.Course)
            //    .WithOptional(i => i.FkStuCourse);

            base.OnModelCreating(modelBuilder);
        }



    }
}