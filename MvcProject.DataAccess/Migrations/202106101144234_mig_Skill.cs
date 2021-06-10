namespace MvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_Skill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TalentCards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        Text = c.String(maxLength: 50),
                        Skill = c.String(maxLength: 20),
                        SkillPuan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TalentCards");
        }
    }
}
