namespace MVCCourse2017.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastUpdates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
