using FluentMigrator;

namespace Migrator.Migrations
{
    [Migration(7)]
    public class CostModelHierarchy : Migration
    {
        public override void Up()
        {
            Alter.Table("tblCostModel").AddColumn("ParentId").AsInt32().Nullable().ForeignKey("tblCostModel", "Id");
        }

        public override void Down()
        {
            Delete.Column("ParentId").FromTable("tblCostModel");
        }
    }
}