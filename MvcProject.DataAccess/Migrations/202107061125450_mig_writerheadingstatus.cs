namespace MvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writerheadingstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "IsWriterHeading", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headings", "IsWriterHeading");
        }
    }
}
