namespace MVCCourse2017.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmplyee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpID = c.Long(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 100),
                        BirthDate = c.DateTime(nullable: false),
                        Salary = c.Double(nullable: false),
                        DepartID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
