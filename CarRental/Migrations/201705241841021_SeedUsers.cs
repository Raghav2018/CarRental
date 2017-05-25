namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'609b6576-7051-49db-8c4a-ad3492aa72e3', N'admin@carly.com', 0, N'APelmpuAWt4qEFRkiShNMtNc1jpLWWIA//j7uxV8gUgEhduT04wT2QBkri7pMOIcpw==', N'afff5315-a80c-4a6a-8adc-7be9ff9acafd', NULL, 0, 0, NULL, 1, 0, N'admin@carly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e7687c51-54ab-43a0-95f0-e8bd155d301f', N'guest@carly.com', 0, N'AKW+Pbl/44NvejOo84HwVc3e5k8e0WuuscbjqDQWIps2ZGkhvn8xv/9tdkP2JG/Uww==', N'f1009355-caec-429c-b777-5728303656aa', NULL, 0, 0, NULL, 1, 0, N'guest@carly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e01af4d5-c983-4230-a951-7cf3855f9906', N'CanManageCars')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'609b6576-7051-49db-8c4a-ad3492aa72e3', N'e01af4d5-c983-4230-a951-7cf3855f9906')
                ");
        }
        public override void Down()
        {
        }
    }
}
