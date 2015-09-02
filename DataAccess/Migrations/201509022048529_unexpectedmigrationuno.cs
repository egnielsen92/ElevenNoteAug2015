namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unexpectedmigrationuno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Note", "DataCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Note", "DataCreated");
        }
    }
}
