﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DataBaseContext
{
    public class UniversityDbContext:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<AllocateClassRoom> AllocateClassRooms { get; set; }
        public DbSet<CourseAssignToTeacher> CourseAssignToTeachers { get; set; }

        public DbSet<Day> Days { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<EnrollCourse> EnrollCourses { get; set; }
        public DbSet<StudentResult> StudentResults { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}