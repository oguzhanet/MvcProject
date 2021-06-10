namespace MvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_SkillP10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TalentCards", "Skill2", c => c.String(maxLength: 20));
            AddColumn("dbo.TalentCards", "SkillPoint2", c => c.String(maxLength: 3));
            AddColumn("dbo.TalentCards", "Skill3", c => c.String(maxLength: 20));
            AddColumn("dbo.TalentCards", "SkillPoint3", c => c.String(maxLength: 3));
            AddColumn("dbo.TalentCards", "Skill4", c => c.String(maxLength: 20));
            AddColumn("dbo.TalentCards", "SkillPoint4", c => c.String(maxLength: 3));
            AddColumn("dbo.TalentCards", "Skill5", c => c.String(maxLength: 20));
            AddColumn("dbo.TalentCards", "SkillPoint5", c => c.String(maxLength: 3));
            AddColumn("dbo.TalentCards", "Skill6", c => c.String(maxLength: 20));
            AddColumn("dbo.TalentCards", "SkillPoint6", c => c.String(maxLength: 3));
            AddColumn("dbo.TalentCards", "Skill7", c => c.String(maxLength: 20));
            AddColumn("dbo.TalentCards", "SkillPoint7", c => c.String(maxLength: 3));
            AddColumn("dbo.TalentCards", "Skill8", c => c.String(maxLength: 20));
            AddColumn("dbo.TalentCards", "SkillPoint8", c => c.String(maxLength: 3));
            AddColumn("dbo.TalentCards", "Skill9", c => c.String(maxLength: 20));
            AddColumn("dbo.TalentCards", "SkillPoint9", c => c.String(maxLength: 3));
            AddColumn("dbo.TalentCards", "Skill10", c => c.String(maxLength: 20));
            AddColumn("dbo.TalentCards", "SkillPoint10", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TalentCards", "SkillPoint10");
            DropColumn("dbo.TalentCards", "Skill10");
            DropColumn("dbo.TalentCards", "SkillPoint9");
            DropColumn("dbo.TalentCards", "Skill9");
            DropColumn("dbo.TalentCards", "SkillPoint8");
            DropColumn("dbo.TalentCards", "Skill8");
            DropColumn("dbo.TalentCards", "SkillPoint7");
            DropColumn("dbo.TalentCards", "Skill7");
            DropColumn("dbo.TalentCards", "SkillPoint6");
            DropColumn("dbo.TalentCards", "Skill6");
            DropColumn("dbo.TalentCards", "SkillPoint5");
            DropColumn("dbo.TalentCards", "Skill5");
            DropColumn("dbo.TalentCards", "SkillPoint4");
            DropColumn("dbo.TalentCards", "Skill4");
            DropColumn("dbo.TalentCards", "SkillPoint3");
            DropColumn("dbo.TalentCards", "Skill3");
            DropColumn("dbo.TalentCards", "SkillPoint2");
            DropColumn("dbo.TalentCards", "Skill2");
        }
    }
}
