namespace DatabaseDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMayToMay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FKStuCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FKStuCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.FKStuCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.FKStuCourses", new[] { "CourseId" });
            DropIndex("dbo.FKStuCourses", new[] { "StudentId" });
            DropTable("dbo.FKStuCourses");
        }
    }
}
