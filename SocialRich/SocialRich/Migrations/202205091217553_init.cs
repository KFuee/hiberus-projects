namespace SocialRich.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SocialNetworks",
                c => new
                    {
                        SocialNetworkId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SocialNetworkId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        FavouriteSocialNetworkId = c.Long(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.SocialNetworks", t => t.FavouriteSocialNetworkId)
                .Index(t => t.FavouriteSocialNetworkId);
            
            CreateTable(
                "dbo.SocialNetworkUsers",
                c => new
                    {
                        SocialNetwork_SocialNetworkId = c.Long(nullable: false),
                        User_UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.SocialNetwork_SocialNetworkId, t.User_UserId })
                .ForeignKey("dbo.SocialNetworks", t => t.SocialNetwork_SocialNetworkId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.SocialNetwork_SocialNetworkId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocialNetworkUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.SocialNetworkUsers", "SocialNetwork_SocialNetworkId", "dbo.SocialNetworks");
            DropForeignKey("dbo.Users", "FavouriteSocialNetworkId", "dbo.SocialNetworks");
            DropIndex("dbo.SocialNetworkUsers", new[] { "User_UserId" });
            DropIndex("dbo.SocialNetworkUsers", new[] { "SocialNetwork_SocialNetworkId" });
            DropIndex("dbo.Users", new[] { "FavouriteSocialNetworkId" });
            DropTable("dbo.SocialNetworkUsers");
            DropTable("dbo.Users");
            DropTable("dbo.SocialNetworks");
        }
    }
}
