namespace GaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "StreetId", "dbo.Street");
            DropForeignKey("dbo.Posts", "AddressId", "dbo.Address");
            DropForeignKey("dbo.PolicemenInPost", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "PostId", "dbo.Desicion");
            DropForeignKey("dbo.InfrigmentInDecision", "DecisionId", "dbo.Desicion");
            DropForeignKey("dbo.Desicion", "DriverLicense", "dbo.Driver");
            DropForeignKey("dbo.Auto", "DriverLicense", "dbo.Driver");
            DropForeignKey("dbo.Desicion", "AutoId", "dbo.Auto");
            DropForeignKey("dbo.Auto", "ColorId", "dbo.Color");
            DropForeignKey("dbo.AutoType", "ModelId", "dbo.Model");
            DropForeignKey("dbo.AutoType", "MakeId", "dbo.Make");
            DropForeignKey("dbo.Auto", new[] { "MakeId", "ModelId" }, "dbo.AutoType");
            DropForeignKey("dbo.InfrigmentsInArticle", "InfrigmentId", "dbo.Infrigment");
            DropForeignKey("dbo.InfrigmentsInArticle", "ArticleCode", "dbo.Article");
            DropForeignKey("dbo.Infrigment", "InfrigmentKindId", "dbo.InfrigmentKind");
            DropForeignKey("dbo.InfrigmentInDecision", "InfrigmentId", "dbo.Infrigment");
            DropForeignKey("dbo.Punishment", new[] { "DecisionId", "InfrigmentId" }, "dbo.InfrigmentInDecision");
            DropForeignKey("dbo.PunishmentExecution", new[] { "DesicionId", "InfrigmentId" }, "dbo.Punishment");
            DropForeignKey("dbo.Punishment", "PolicemanNumber", "dbo.Policeman");
            DropForeignKey("dbo.PolicemenInPost", "PolicemanNumber", "dbo.Policeman");
            DropForeignKey("dbo.Desicion", "PolicemanNumber", "dbo.Policeman");
            DropForeignKey("dbo.Desicion", "ArticleCode", "dbo.Article");
            DropForeignKey("dbo.Address", "DistrictId", "dbo.District");
            DropIndex("dbo.InfrigmentsInArticle", new[] { "InfrigmentId" });
            DropIndex("dbo.InfrigmentsInArticle", new[] { "ArticleCode" });
            DropIndex("dbo.AutoType", new[] { "ModelId" });
            DropIndex("dbo.AutoType", new[] { "MakeId" });
            DropIndex("dbo.Auto", new[] { "ColorId" });
            DropIndex("dbo.Auto", new[] { "MakeId", "ModelId" });
            DropIndex("dbo.Auto", new[] { "DriverLicense" });
            DropIndex("dbo.PunishmentExecution", new[] { "DesicionId", "InfrigmentId" });
            DropIndex("dbo.PolicemenInPost", new[] { "PolicemanNumber" });
            DropIndex("dbo.PolicemenInPost", new[] { "PostId" });
            DropIndex("dbo.Punishment", new[] { "PolicemanNumber" });
            DropIndex("dbo.Punishment", new[] { "DecisionId", "InfrigmentId" });
            DropIndex("dbo.InfrigmentInDecision", new[] { "DecisionId" });
            DropIndex("dbo.InfrigmentInDecision", new[] { "InfrigmentId" });
            DropIndex("dbo.Infrigment", new[] { "InfrigmentKindId" });
            DropIndex("dbo.Desicion", new[] { "PolicemanNumber" });
            DropIndex("dbo.Desicion", new[] { "ArticleCode" });
            DropIndex("dbo.Desicion", new[] { "DriverLicense" });
            DropIndex("dbo.Desicion", new[] { "AutoId" });
            DropIndex("dbo.Posts", new[] { "AddressId" });
            DropIndex("dbo.Posts", new[] { "PostId" });
            DropIndex("dbo.Address", new[] { "DistrictId" });
            DropIndex("dbo.Address", new[] { "StreetId" });
            DropTable("dbo.InfrigmentsInArticle");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.PunishmentsView");
            DropTable("dbo.ArticlesView");
            DropTable("dbo.Street");
            DropTable("dbo.Driver");
            DropTable("dbo.Color");
            DropTable("dbo.Model");
            DropTable("dbo.Make");
            DropTable("dbo.AutoType");
            DropTable("dbo.Auto");
            DropTable("dbo.InfrigmentKind");
            DropTable("dbo.PunishmentExecution");
            DropTable("dbo.PolicemenInPost");
            DropTable("dbo.Policeman");
            DropTable("dbo.Punishment");
            DropTable("dbo.InfrigmentInDecision");
            DropTable("dbo.Infrigment");
            DropTable("dbo.Article");
            DropTable("dbo.Desicion");
            DropTable("dbo.Posts");
            DropTable("dbo.District");
            DropTable("dbo.Address");
        }
    }
}
