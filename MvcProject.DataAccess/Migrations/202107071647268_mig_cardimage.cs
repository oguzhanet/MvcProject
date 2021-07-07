namespace MvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_cardimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TalentCards", "Image", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TalentCards", "Image");
        }
    }
}
