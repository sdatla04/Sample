namespace Vidly082018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAddeddToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "DateAdded");
        }
    }
}
