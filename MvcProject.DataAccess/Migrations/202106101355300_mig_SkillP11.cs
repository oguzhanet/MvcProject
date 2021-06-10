namespace MvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_SkillP11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TalentCards", "SkillPoint", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TalentCards", "SkillPoint", c => c.String(maxLength: 3));
        }
    }
}
