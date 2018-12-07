using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }

        public int SemesterId { get; set; }
        public string Name{ get; set; }
        public string Code{ get; set; }
        public double Credit { get; set; }
        public string Description{ get; set; }
        


        [NotMapped]
        public List<Department> Departments { get; set; }
    }
}