namespace MvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_Skillid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TalentCards", "SkillId", c => c.Int(nullable: false));
            CreateIndex("dbo.TalentCards", "SkillId");
            AddForeignKey("dbo.TalentCards", "SkillId", "dbo.TalentCardSkills", "SkillId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TalentCards", "SkillId", "dbo.TalentCardSkills");
            DropIndex("dbo.TalentCards", new[] { "SkillId" });
            DropColumn("dbo.TalentCards", "SkillId");
        }
    }
}
