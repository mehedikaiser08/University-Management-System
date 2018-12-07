using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class AllocateClassRoom
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public Room Room { get; set; }
        public Day Day { get; set; }

        public Department Department { get; set; }
        public Course Course { get; set; }

        [NotMapped]
        public List<Department> Departments { get; set; }
        [NotMapped]
        public List<Course> Courses { get; set; }
    }
}