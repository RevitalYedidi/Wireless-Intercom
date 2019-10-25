namespace NEW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "TenantId", c => c.Int(nullable: false));
            AddColumn("dbo.Notifications", "GuestMessage", c => c.String(maxLength: 255));
            AddColumn("dbo.Notifications", "ImgUrl", c => c.String(maxLength: 255));
            AddColumn("dbo.Notifications", "IsOpen", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "IsOpen");
            DropColumn("dbo.Notifications", "ImgUrl");
            DropColumn("dbo.Notifications", "GuestMessage");
            DropColumn("dbo.Notifications", "TenantId");
        }
    }
}
