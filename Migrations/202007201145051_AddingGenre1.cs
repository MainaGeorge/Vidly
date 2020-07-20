namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddingGenre1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO genres(Id, Name) VALUES(1, 'COMEDY')");
            Sql("INSERT INTO genres(Id, Name) VALUES(2, 'ROMANCE')");
            Sql("INSERT INTO genres(Id, Name) VALUES(3, 'ACTION')");
            Sql("INSERT INTO genres(Id, Name) VALUES(4, 'HORROR')");
            Sql("INSERT INTO genres(Id, Name) VALUES(5, 'SCI-FI')");
            Sql("INSERT INTO genres(Id, Name) VALUES(6, 'ADULT')");
        }

        public override void Down()
        {
            Sql("DELETE FROM genres WHERE Id = 1");
            Sql("DELETE FROM genres WHERE Id = 2");
            Sql("DELETE FROM genres WHERE Id = 3");
            Sql("DELETE FROM genres WHERE Id = 4");
            Sql("DELETE FROM genres WHERE Id = 5");
            Sql("DELETE FROM genres WHERE Id = 6");
            Sql("DELETE FROM genres WHERE Id = 7");
        }
    }
}
