using System;
using System.Collections.Generic;

namespace WebApplicationDB.Models
{
    public partial class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; } = null!;
    }
}
