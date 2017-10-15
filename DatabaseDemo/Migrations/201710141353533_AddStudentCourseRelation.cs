namespace DatabaseDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentCourseRelation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Prices", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Prices", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
