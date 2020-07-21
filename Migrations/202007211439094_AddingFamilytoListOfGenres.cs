namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddingFamilyToListOfGenres : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into genres(Id,Name) values(7,'FAMILY')");
            Sql("Insert into genres(Id,Name) values(8,'ANIMATION')");
        }

        public override void Down()
        {
            Sql("DELETE FROM genres WHERE id = 6");
            Sql("DELETE FROM genres WHERE id = 7");
        }
    }
}
