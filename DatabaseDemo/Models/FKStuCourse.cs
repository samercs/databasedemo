using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Helpers;

namespace DatabaseDemo.Models
{
    public class FKStuCourse
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}