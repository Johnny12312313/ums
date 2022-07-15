using System;
using System.Collections.Generic;

namespace WebApplicationDB.Models
{
    public partial class User
    {
        public User()
        {
            StudentByCourses = new HashSet<StudentByCourse>();
            TeacherByCourses = new HashSet<TeacherByCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
        public DateTime? InsertedAt { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<StudentByCourse> StudentByCourses { get; set; }
        public virtual ICollection<TeacherByCourse> TeacherByCourses { get; set; }
    }
}
