namespace Vidly3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'20198b1d-7ea7-4eb3-b8f5-6772492c39fd', N'guest@vidly.com', 0, N'AHQTYevbaGjEIGKKdFxQGTrDAbjtIUb/Oh3B6FOHw49cGXRp4xPuiaF9r8cNtqrQcA==', N'e759a697-0533-49e8-9c38-4936c3d12361', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8aab5e9b-6aa9-4394-8321-92b44d338978', N'admin@vidly.com', 0, N'AG7GmGzYQimPvFD2JCnP5hgcAGg8bMI9WkM0hkp0fJe7oEuZ9Gs98jp1+3sbbRpE+g==', N'b8a5dd4f-72cf-4754-9bac-da8ff41a1001', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5e14f396-5941-4fbd-ae66-90cad6ca37d4', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8aab5e9b-6aa9-4394-8321-92b44d338978', N'5e14f396-5941-4fbd-ae66-90cad6ca37d4')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
