namespace MVCCourse2017.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1cdae2af-f3e1-4cbe-84e8-5b66ac769122', N'admin@gmail.com', 0, N'ABZiHv+V8GEsXcfLw74Ph5BawyyqGsPoo9V9iyBDVDwPXexeKkCVz00SNafoQzCVvQ==', N'1b81c237-a91b-4ee7-9da3-76bdd3a44d67', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c77dff6c-37fe-49b1-b8f8-d061499eb7b0', N'omrs2002@yahoo.com', 0, N'AABQjm5On5Fja2nvgtTQ74Bwp4CrK3GP/PUNrLl/GRDKRe2F74QGfnzF3rCX4LYuyA==', N'5f159bd8-cc4e-4322-bf96-3a2f269c1ad3', NULL, 0, 0, NULL, 1, 0, N'omrs2002@yahoo.com')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ef02d457-0fe1-4e78-8c6d-e97865996a62', N'CanManageMovies')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1cdae2af-f3e1-4cbe-84e8-5b66ac769122', N'ef02d457-0fe1-4e78-8c6d-e97865996a62')"
                );

        }
        
        public override void Down()
        {
            Sql(@"
            DELETE FROM  [dbo].[AspNetUsers] 
            DELETE FROM [dbo].[AspNetUsers] 
            DELETE FROM [dbo].[AspNetRoles] 
            DELETE FROM [dbo].[AspNetUserRoles]
");

        }
    }
}
