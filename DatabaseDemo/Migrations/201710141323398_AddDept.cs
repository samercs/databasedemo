namespace DatabaseDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDept : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "DeptId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "DeptId");
            AddForeignKey("dbo.Students", "DeptId", "dbo.Departments", "Id", cascadeDelete: true);
            DropColumn("dbo.Students", "DeptName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "DeptName", c => c.String());
            DropForeignKey("dbo.Students", "DeptId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DeptId" });
            DropColumn("dbo.Students", "DeptId");
            DropTable("dbo.Departments");
        }
    }
}
