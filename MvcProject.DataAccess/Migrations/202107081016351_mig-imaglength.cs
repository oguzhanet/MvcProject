namespace MvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migimaglength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ImageFiles", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ImageFiles", "ImagePath", c => c.String(maxLength: 500));
        }
    }
}
