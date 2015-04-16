using System;
using FluentMigrator;

namespace Migrator.Migrations
{
    [Migration(4)]
    public class TestPeriodData : Migration
    {
        public override void Up()
        {
            Update.Table("tblCostModel")
                  .Set(new {PeriodCount = 1})
                  .AllRows();

            Insert.IntoTable("tblCostModelPeriod")
                  .Row(new {Version = 1, fkCostModel = 1, Order = 1, Start = new DateTime(2015, 3, 16), End = new DateTime(2015, 3, 22)})
                  .Row(new {Version = 1, fkCostModel = 2, Order = 1, Start = new DateTime(2015, 3, 9), End = new DateTime(2015, 3, 15)});
        }

        public override void Down()
        {
            Update.Table("tblCostModel")
                  .Set(new { PeriodCount = 0 })
                  .AllRows(); 

            Delete.FromTable("tblCostModelPeriod").AllRows();
        }
    }
}