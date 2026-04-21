namespace BaiTapMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassSections",
                c => new
                    {
                        ClassSectionId = c.Int(nullable: false, identity: true),
                        Semester = c.String(),
                        CourseId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassSectionId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        ClassSectionId = c.Int(nullable: false),
                        EnrollDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentId)
                .ForeignKey("dbo.ClassSections", t => t.ClassSectionId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.ClassSectionId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassSections", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "ClassSectionId", "dbo.ClassSections");
            DropForeignKey("dbo.ClassSections", "CourseId", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "ClassSectionId" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.ClassSections", new[] { "TeacherId" });
            DropIndex("dbo.ClassSections", new[] { "CourseId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Courses");
            DropTable("dbo.ClassSections");
        }
    }
}
