using System;
using System.Collections.Generic;

namespace WebApplicationDB.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentByCourses = new HashSet<StudentByCourse>();
            TeacherByCourses = new HashSet<TeacherByCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Credits { get; set; }

        public virtual ICollection<StudentByCourse> StudentByCourses { get; set; }
        public virtual ICollection<TeacherByCourse> TeacherByCourses { get; set; }
    }
}
