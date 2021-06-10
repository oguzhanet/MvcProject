namespace MvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_SkillP : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TalentCards", "SkillId", "dbo.TalentCardSkills");
            DropIndex("dbo.TalentCards", new[] { "SkillId" });
            AddColumn("dbo.TalentCards", "Skill", c => c.String(maxLength: 20));
            AddColumn("dbo.TalentCards", "SkillPoint", c => c.String(maxLength: 3));
            DropColumn("dbo.TalentCards", "SkillId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TalentCards", "SkillId", c => c.Int(nullable: false));
            DropColumn("dbo.TalentCards", "SkillPoint");
            DropColumn("dbo.TalentCards", "Skill");
            CreateIndex("dbo.TalentCards", "SkillId");
            AddForeignKey("dbo.TalentCards", "SkillId", "dbo.TalentCardSkills", "SkillId", cascadeDelete: true);
        }
    }
}
