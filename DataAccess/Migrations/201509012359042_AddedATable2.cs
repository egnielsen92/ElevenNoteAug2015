namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedATable2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.OkToDelete");
            AlterColumn("dbo.OkToDelete", "SomeColumn", c => c.String());
            AlterColumn("dbo.OkToDelete", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.OkToDelete", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.OkToDelete");
            AlterColumn("dbo.OkToDelete", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.OkToDelete", "SomeColumn", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.OkToDelete", "SomeColumn");
        }
    }
}
