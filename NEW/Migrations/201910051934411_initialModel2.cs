namespace NEW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialModel2 : DbMigration
    {
        public override void Up()
        {
           
            //AddColumn("dbo.Entrances", "Id", c => c.Int(nullable: false, identity: true));
            //AlterColumn("dbo.Entrances", "BuildingId", c => c.Int(nullable: false));
            //AddPrimaryKey("dbo.Entrances", "Id");
        }
        
        public override void Down()
        {
        //    DropPrimaryKey("dbo.Entrances");
        //    AlterColumn("dbo.Entrances", "BuildingId", c => c.Int(nullable: false, identity: true));
        //    DropColumn("dbo.Entrances", "Id");
        //    AddPrimaryKey("dbo.Entrances", "BuildingId");
        }
    }
}
