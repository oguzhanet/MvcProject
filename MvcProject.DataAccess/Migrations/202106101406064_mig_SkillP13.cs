namespace MvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_SkillP13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TalentCards", "SkillPoint2", c => c.Int(nullable: false));
            AlterColumn("dbo.TalentCards", "SkillPoint3", c => c.Int(nullable: false));
            AlterColumn("dbo.TalentCards", "SkillPoint4", c => c.Int(nullable: false));
            AlterColumn("dbo.TalentCards", "SkillPoint5", c => c.Int(nullable: false));
            AlterColumn("dbo.TalentCards", "SkillPoint6", c => c.Int(nullable: false));
            AlterColumn("dbo.TalentCards", "SkillPoint7", c => c.Int(nullable: false));
            AlterColumn("dbo.TalentCards", "SkillPoint8", c => c.Int(nullable: false));
            AlterColumn("dbo.TalentCards", "SkillPoint9", c => c.Int(nullable: false));
            AlterColumn("dbo.TalentCards", "SkillPoint10", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TalentCards", "SkillPoint10", c => c.String(maxLength: 3));
            AlterColumn("dbo.TalentCards", "SkillPoint9", c => c.String(maxLength: 3));
            AlterColumn("dbo.TalentCards", "SkillPoint8", c => c.String(maxLength: 3));
            AlterColumn("dbo.TalentCards", "SkillPoint7", c => c.String(maxLength: 3));
            AlterColumn("dbo.TalentCards", "SkillPoint6", c => c.String(maxLength: 3));
            AlterColumn("dbo.TalentCards", "SkillPoint5", c => c.String(maxLength: 3));
            AlterColumn("dbo.TalentCards", "SkillPoint4", c => c.String(maxLength: 3));
            AlterColumn("dbo.TalentCards", "SkillPoint3", c => c.String(maxLength: 3));
            AlterColumn("dbo.TalentCards", "SkillPoint2", c => c.String(maxLength: 3));
        }
    }
}
