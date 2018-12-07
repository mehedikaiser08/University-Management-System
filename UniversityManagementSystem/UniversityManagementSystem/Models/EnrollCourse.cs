﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class EnrollCourse
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
       
        public DateTime Date { get; set; }

        [NotMapped]
        public List<Student> Students { get; set; }
        [NotMapped]
        public List<Course> Courses { get; set; }
    }
}