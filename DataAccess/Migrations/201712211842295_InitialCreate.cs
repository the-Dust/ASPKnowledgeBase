namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                        Author = c.String(nullable: false, maxLength: 2000),
                        Email = c.String(nullable: false, maxLength: 2000),
                        ThemeId = c.Int(nullable: false),
                        Question = c.String(nullable: false, maxLength: 2000),
                        Answer = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Themes", t => t.ThemeId, cascadeDelete: true)
                .Index(t => t.ThemeId);
            
            CreateTable(
                "dbo.Themes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "ThemeId", "dbo.Themes");
            DropIndex("dbo.Questions", new[] { "ThemeId" });
            DropTable("dbo.Themes");
            DropTable("dbo.Questions");
        }
    }
}
