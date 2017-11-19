namespace MVCCourse2017.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id,Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (1,'A1', 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes (Id,Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (3,'A2', 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes (Id,Name, SignUpFee, DurationInMonths, DiscountRate) VALUES (4,'A3', 300, 12, 20)");
        }

        public override void Down()
        {
            Sql("Delete from MembershipTypes ;");

            


        }
    }
}
