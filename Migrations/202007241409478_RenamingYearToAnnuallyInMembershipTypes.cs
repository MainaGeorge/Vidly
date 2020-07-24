namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RenamingYearToAnnuallyInMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE membershipTypes SET name = 'Annual' WHERE Id = 4");
        }

        public override void Down()
        {
            Sql("UPDATE membershipTypes SET name = 'Year' WHERE Id = 4");
        }
    }
}
