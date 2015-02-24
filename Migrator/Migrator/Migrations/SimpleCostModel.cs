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
                .WithColumn("Description").AsString(256);

            Create.Table("tblUser_CostModelGroup")
                .WithColumn("fkCostModelGroup").AsInt32().ForeignKey("tblCostModelGroup", "Id")
                .WithColumn("fkUser").AsGuid().ForeignKey("TblUser", "UserID");

            Create.PrimaryKey("pkUserCostModelGroup").OnTable("tblUser_CostModelGroup")
                .Columns("fkCostModelGroup", "fkUser");

            Create.Table("tblCostModel")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(256)
                .WithColumn("UID").AsString(128).Unique()
                .WithColumn("Description").AsString(512)
                .WithColumn("StartDate").AsCustom("datetime2").Nullable()
                .WithColumn("CancellationDate").AsCustom("datetime2").Nullable()
                .WithColumn("CompletionDate").AsCustom("datetime2").Nullable()
                .WithColumn("Status").AsString(52)
                .WithColumn("fkCostModelGroup").AsInt32().ForeignKey("tblCostModelGroup", "Id");
        }
    }
}