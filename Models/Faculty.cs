using System;
using System.Collections.Generic;

namespace WebApplicationDB.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            Departments = new HashSet<Department>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Department> Departments { get; set; }
    }
}
