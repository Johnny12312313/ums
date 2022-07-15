using System;
using System.Collections.Generic;

namespace WebApplicationDB.Models
{
    public partial class TeacherByCourse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
