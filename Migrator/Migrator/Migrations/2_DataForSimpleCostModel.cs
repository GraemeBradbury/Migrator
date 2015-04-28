using System;

using FluentMigrator;
using FluentMigrator.Runner.Extensions;

namespace Migrator.Migrations
{
    [Migration(2)]
    public class DataForSimpleCostModel : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("tblCostModelGroup").WithIdentityInsert()
                .Row(new { Id = 1, Description = "Testing User Group (Large)", CreatedDate = new DateTime(2015,2,13) })
                .Row(new { Id = 2, Description = "Testing User Group Two", CreatedDate = new DateTime(2015,2,13) });

            Insert.IntoTable("tblUser_CostModelGroup")
                .Row(new { fkUser = "f5fff08b-fe16-e411-9e15-2c413887bd4b", fkCostModelGroup = 1, CreatedDate = new DateTime(2015, 2, 13) })
                .Row(new { fkUser = "b2d9478b-d476-e311-9064-2c413887bd4b", fkCostModelGroup = 1, CreatedDate = new DateTime(2015, 2, 13) })
                .Row(new { fkUser = "196fedcf-1af0-e011-bfc4-0019db8d4a56", fkCostModelGroup = 1, CreatedDate = new DateTime(2015, 2, 13) })
                .Row(new { fkUser = "f75b8b2d-00f7-e311-9e15-2c413887bd4b", fkCostModelGroup = 1, CreatedDate = new DateTime(2015, 2, 13) })
                .Row(new { fkUser = "143d0012-9227-e411-9e15-2c413887bd4b", fkCostModelGroup = 1, CreatedDate = new DateTime(2015, 2, 13) })
                .Row(new { fkUser = "196fedcf-1af0-e011-bfc4-0019db8d4a56", fkCostModelGroup = 2, CreatedDate = new DateTime(2015, 2, 13) })
                .Row(new { fkUser = "f5fff08b-fe16-e411-9e15-2c413887bd4b", fkCostModelGroup = 2, CreatedDate = new DateTime(2015, 2, 13) });


            Insert.IntoTable("tblCostModel").WithIdentityInsert()
                .Row(
                    new
                    {
                        Id = 1,
                        Title = "Test Budget One",
                        UID = "Test Budget One - 2015",
                        Description = "Test budget for the year 2015",
                        Status = "draft",
                        fkCostModelGroup = 1,
                        CreatedDate = new DateTime(2015,2,13),
                        Type = "budget",
                        PeriodCount = 0,
                        PeriodFrequency = "week",
                        PeriodStartDate = new DateTime(2015,9,9),
                        CostCentre = "budget",
                        CostAllocation = "",
                        Version = 1
                    })
                .Row(
                    new
                    {
                        Id = 2,
                        Title = "Test Budget Two",
                        UID = "Test Budget Two - 2015",
                        Description = "Test budget for the year 2015",
                        Status = "draft",
                        fkCostModelGroup = 2,
                        CreatedDate = new DateTime(2015,2,13),
                        Type = "budget",
                        PeriodCount = 0,
                        PeriodFrequency = "week",
                        PeriodStartDate = new DateTime(2015, 9, 9),
                        CostCentre = "budget",
                        CostAllocation = "",
                        Version = 1
                    });
        }

        public override void Down()
        {
            Delete.FromTable("tblUser_CostModelGroup").AllRows();
            Delete.FromTable("tblCostModel").AllRows();
            Delete.FromTable("tblCostModelGroup").AllRows();
        }
    }
}