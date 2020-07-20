using System.Data.Entity.Migrations.Model;

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulatingNameForExistingMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE membershipTypes SET name = 'Pay As You Go' WHERE Id = 1");
            Sql("UPDATE membershipTypes SET name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE membershipTypes SET name = '3 Months' WHERE Id = 3");
            Sql("UPDATE membershipTypes SET name = 'Year' WHERE Id = 4");
        }

        public override void Down()
        {
            Sql("UPDATE membershipTypes SET name = '' WHERE id = 1");
            Sql("UPDATE membershipTypes SET name = '' WHERE id = 2");
            Sql("UPDATE membershipTypes SET name = '' WHERE id = 3");
            Sql("UPDATE membershipTypes SET name = '' WHERE id = 4");
        }
    }
}
