namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model_Completed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllocateClassRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Course_Id = c.Int(),
                        Day_Id = c.Int(),
                        Department_Id = c.Int(),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Days", t => t.Day_Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Day_Id)
                .Index(t => t.Department_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        Credit = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomNO = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseAssignToTeachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RemainingCredit = c.Double(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        ContactNo = c.String(),
                        CreditToBeTaken = c.Double(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EnrollCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Course_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RegNo = c.String(),
                        Email = c.String(),
                        ContactNo = c.String(),
                        Date = c.DateTime(nullable: false),
                        Address = c.String(),
                        Department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .Index(t => t.Department_Id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Course_Id = c.Int(),
                        Grade_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Grades", t => t.Grade_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Grade_Id)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentResults", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.StudentResults", "Grade_Id", "dbo.Grades");
            DropForeignKey("dbo.StudentResults", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.EnrollCourses", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.EnrollCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.CourseAssignToTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.CourseAssignToTeachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.CourseAssignToTeachers", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.AllocateClassRooms", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.AllocateClassRooms", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.AllocateClassRooms", "Day_Id", "dbo.Days");
            DropForeignKey("dbo.AllocateClassRooms", "Course_Id", "dbo.Courses");
            DropIndex("dbo.StudentResults", new[] { "Student_Id" });
            DropIndex("dbo.StudentResults", new[] { "Grade_Id" });
            DropIndex("dbo.StudentResults", new[] { "Course_Id" });
            DropIndex("dbo.Students", new[] { "Department_Id" });
            DropIndex("dbo.EnrollCourses", new[] { "Student_Id" });
            DropIndex("dbo.EnrollCourses", new[] { "Course_Id" });
            DropIndex("dbo.CourseAssignToTeachers", new[] { "CourseId" });
            DropIndex("dbo.CourseAssignToTeachers", new[] { "TeacherId" });
            DropIndex("dbo.CourseAssignToTeachers", new[] { "DepartmentId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "Room_Id" });
            DropIndex("dbo.AllocateClassRooms", new[] { "Department_Id" });
            DropIndex("dbo.AllocateClassRooms", new[] { "Day_Id" });
            DropIndex("dbo.AllocateClassRooms", new[] { "Course_Id" });
            DropTable("dbo.StudentResults");
            DropTable("dbo.Semesters");
            DropTable("dbo.Grades");
            DropTable("dbo.Students");
            DropTable("dbo.EnrollCourses");
            DropTable("dbo.Designations");
            DropTable("dbo.Teachers");
            DropTable("dbo.CourseAssignToTeachers");
            DropTable("dbo.Rooms");
            DropTable("dbo.Departments");
            DropTable("dbo.Days");
            DropTable("dbo.Courses");
            DropTable("dbo.AllocateClassRooms");
        }
    }
}
