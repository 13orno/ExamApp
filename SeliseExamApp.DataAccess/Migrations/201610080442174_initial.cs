namespace SeliseExamApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Code = c.String(maxLength: 20),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 30),
                        Roll = c.String(nullable: false, maxLength: 20),
                        Address = c.String(maxLength: 250),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_StudentId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Course_CourseId })
                .ForeignKey("dbo.Student", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_CourseId, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Course_CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "Course_CourseId", "dbo.Course");
            DropForeignKey("dbo.StudentCourses", "Student_StudentId", "dbo.Student");
            DropIndex("dbo.StudentCourses", new[] { "Course_CourseId" });
            DropIndex("dbo.StudentCourses", new[] { "Student_StudentId" });
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Student");
            DropTable("dbo.Course");
        }
    }
}
