namespace Restaurantes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestaurantReviews",
                c => new
                    {
                        RestaurantReviewId = c.Long(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Body = c.String(nullable: false),
                        ReviewerName = c.String(),
                        RestaurantId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantReviewId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        City = c.String(nullable: false, maxLength: 30),
                        Country = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantReviews", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.RestaurantReviews", new[] { "RestaurantId" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.RestaurantReviews");
        }
    }
}
