namespace Vidly082018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (Id,Name) Values (1,'Action')" );
            Sql("Insert into Genres (Id,Name) Values (2,'Thriller')");
            Sql("Insert into Genres (Id,Name) Values (3,'Drama')");
            Sql("Insert into Genres (Id,Name) Values (4,'Romance')");
            Sql("Insert into Genres (Id,Name) Values (5,'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
