namespace MvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migimagenamelength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ImageFiles", "ImageName", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ImageFiles", "ImageName", c => c.String(maxLength: 100));
        }
    }
}
