namespace EmployeeTaskAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        HiredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.ETasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        TaskName = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ETasks", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.ETasks", new[] { "EmployeeId" });
            DropTable("dbo.ETasks");
            DropTable("dbo.Employees");
        }
    }
}
