using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class CourseAssignToTeacher
    {
        public int Id { get; set; }
        public double RemainingCredit { get; set; }

        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
     

        public Course Course { get; set; }
        public Department Department{ get; set; }
        public Teacher Teacher { get; set; }

        [NotMapped]
        public List<Department> Departments { get; set; }

        [NotMapped]
        public List<Teacher> Teachers { get; set; }
        [NotMapped]

        public List<Course> Courses { get; set; }
    }
}