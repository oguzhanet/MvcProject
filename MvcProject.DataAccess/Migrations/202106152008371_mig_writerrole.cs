﻿namespace MvcProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writerrole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterRole", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterRole");
        }
    }
}
