namespace GaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class policemanPasswordAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Policeman", "Password", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Policeman", "Password");
        }
    }
}
