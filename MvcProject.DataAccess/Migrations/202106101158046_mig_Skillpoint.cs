namespace MvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_Skillpoint : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TalentCardSkills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        Skill = c.String(maxLength: 20),
                        SkillPoint = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.SkillId);
            
            DropColumn("dbo.TalentCards", "Skill");
            DropColumn("dbo.TalentCards", "SkillPuan");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TalentCards", "SkillPuan", c => c.Int(nullable: false));
            AddColumn("dbo.TalentCards", "Skill", c => c.String(maxLength: 20));
            DropTable("dbo.TalentCardSkills");
        }
    }
}
