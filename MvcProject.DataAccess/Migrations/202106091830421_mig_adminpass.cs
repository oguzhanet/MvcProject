namespace MvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adminpass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 20));
        }
    }
}
