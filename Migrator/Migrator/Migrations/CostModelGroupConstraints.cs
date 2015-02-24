using FluentMigrator;

namespace Migrator.Migrations
{
    [Migration(3)]
    public class CostModelGroupConstraints : AutoReversingMigration
    {
        public override void Up()
        {
            Create.UniqueConstraint("ukDescription")
                .OnTable("tblCostModelGroup")
                .Column("Description");
        }
    }
}