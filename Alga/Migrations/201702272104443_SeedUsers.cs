namespace Alga.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
USE [aspnet-Alga-20170215084146]
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6729efd8-326f-41e7-bf9b-893160e24723', N'admin@alga.com', 0, N'ACKTW4sDZlhfQ417FucGnIMwPUQtHpHchviB70eaFzPYL4/ukJWuyBadu13MM7xrbg==', N'79c90e86-bc31-4ac2-9512-e0bca42f50c9', NULL, 0, 0, NULL, 1, 0, N'admin@alga.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6fdcce9b-564f-4538-9aa2-afe2743bcc3d', N'guest@alga.com', 0, N'ADLBH/z/IpU55kUntDxTUL6bL/kP7egc4loDtCVv08lJq6ynMhgPe0cCmzinHpTrcw==', N'3a5fa9bb-b964-48c8-b608-e82dd2437c4e', NULL, 0, 0, NULL, 1, 0, N'guest@alga.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c4c13bf6-2adf-4766-8bd2-04741b0569c5', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6729efd8-326f-41e7-bf9b-893160e24723', N'c4c13bf6-2adf-4766-8bd2-04741b0569c5')

");
        }

        public override void Down()
        {
        }
    }
}
