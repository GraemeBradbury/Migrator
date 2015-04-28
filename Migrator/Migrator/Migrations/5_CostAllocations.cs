using FluentMigrator;

namespace Migrator.Migrations
{
    [Migration(5)]
    public class CostAllocations : Migration
    {
        public override void Up()
        {
            Create.Table("tblCostComponent")
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                  .WithColumn("Description").AsString(50).NotNullable()
                  .WithColumn("ReferenceNumber").AsInt32().NotNullable()
                  .WithColumn("CostCentre").AsString(64).NotNullable().WithDefaultValue("Cost Centre")
                  .WithColumn("CostCentreDescription").AsString(128).NotNullable().WithDefaultValue("Cost Centre")
                  .WithColumn("Active").AsBoolean().NotNullable().WithDefaultValue(true)
                  .WithColumn("Version").AsInt32().NotNullable().WithDefaultValue(1);

            Create.Table("tblCostComponentAllocation")
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                  .WithColumn("fkCostModel").AsInt32().ForeignKey("tblCostModel", "Id")
                  .WithColumn("fkCostComponent").AsInt32().ForeignKey("tblCostComponent", "Id")
                  .WithColumn("Weighting").AsDouble().NotNullable()
                  .WithColumn("Allocation").AsInt32().NotNullable()
                  .WithColumn("Version").AsInt32().NotNullable();

            Alter.Table("tblCostModel")
                 .AddColumn("Allocation").AsInt32().Nullable();
        }

        public override void Down()
        {
            Delete.Table("tblCostComponentAllocation");
            Delete.Table("tblCostComponent");

            Delete.Column("Allocation").FromTable("tblCostModel");
        }
    }
}