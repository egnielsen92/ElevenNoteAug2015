namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixederraneouscolumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Note", "DataCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Note", "DataCreated", c => c.DateTime(nullable: false));
        }
    }
}
