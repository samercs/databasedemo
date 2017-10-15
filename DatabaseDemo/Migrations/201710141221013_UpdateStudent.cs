namespace DatabaseDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "DeptName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "DeptName");
        }
    }
}
