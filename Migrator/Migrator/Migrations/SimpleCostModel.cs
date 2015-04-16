using FluentMigrator;

namespace Migrator.Migrations
{
    [Migration(1)]
    public class SimpleCostModel : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("tblCostModelGroup")
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                  .WithColumn("Description").AsString(256)
                  .WithColumn("CreatedDate").AsCustom("datetimeoffset");

            Create.UniqueConstraint("ukDescription")
                  .OnTable("tblCostModelGroup")
                  .Column("Description");

            Create.Table("tblUser_CostModelGroup")
                  .WithColumn("fkCostModelGroup").AsInt32().ForeignKey("tblCostModelGroup", "Id")
                  .WithColumn("fkUser").AsGuid().ForeignKey("tblUser", "UserID")
                  .WithColumn("CreatedDate").AsCustom("datetimeoffset");

            Create.PrimaryKey("pkUserCostModelGroup").OnTable("tblUser_CostModelGroup")
                  .Columns("fkCostModelGroup", "fkUser");

            Create.Table("tblCostModel")
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                  .WithColumn("Title").AsString(256)
                  .WithColumn("UID").AsString(128).Unique()
                  .WithColumn("Description").AsString(512)
                  .WithColumn("StartDate").AsCustom("datetimeoffset").Nullable()
                  .WithColumn("CancellationDate").AsCustom("datetimeoffset").Nullable()
                  .WithColumn("CompletionDate").AsCustom("datetimeoffset").Nullable()
                  .WithColumn("Status").AsString(52)
                  .WithColumn("fkCostModelGroup").AsInt32().ForeignKey("tblCostModelGroup", "Id")
                  .WithColumn("CreatedDate").AsCustom("datetimeoffset")
                  .WithColumn("Type").AsString(7)
                  .WithColumn("PeriodCount").AsInt32()
                  .WithColumn("PeriodFrequency").AsString(7)
                  .WithColumn("PeriodStartDate").AsCustom("datetimeoffset")
                  .WithColumn("CostCentre").AsString(11)
                  .WithColumn("CostAllocation").AsString(8)
                  .WithColumn("Weighting").AsString(12).Nullable()
                  .WithColumn("Version").AsInt32();
        }
    }
}