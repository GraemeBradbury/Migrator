using System;
using FluentMigrator;

namespace Migrator.Migrations
{
    [Migration(3)]
    public class BudgetPeriod : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("tblCostModelPeriod")
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                  .WithColumn("fkCostModel").AsInt32().ForeignKey("tblCostModel", "Id")
                  .WithColumn("Order").AsInt32().NotNullable()
                  .WithColumn("Start").AsCustom("datetimeoffset")
                  .WithColumn("End").AsCustom("datetimeoffset")
                  .WithColumn("Version").AsInt32();
        }
    }
}