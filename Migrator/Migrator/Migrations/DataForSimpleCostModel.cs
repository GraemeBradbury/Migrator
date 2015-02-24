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
                .Row(new {Id = 1, Description = "Testing User Group One"})
                .Row(new {Id = 2, Description = "Testing User Group Two"});

            Insert.IntoTable("tblUser_CostModelGroup")
                .Row(new {fkUser = "f5fff08b-fe16-e411-9e15-2c413887bd4b", fkCostModelGroup = 1})
                .Row(new {fkUser = "f5fff08b-fe16-e411-9e15-2c413887bd4b", fkCostModelGroup = 2});

            Insert.IntoTable("tblCostModel").WithIdentityInsert()
                .Row(
                    new
                    {
                        Id = 1,
                        Title = "Test Budget One",
                        UID = "Test Budget One - 2015",
                        Description = "Test budget for the year 2015",
                        Status = "Draft",
                        fkCostModelGroup = 1
                    })
                .Row(
                    new
                    {
                        Id = 2,
                        Title = "Test Budget Two",
                        UID = "Test Budget Two - 2015",
                        Description = "Test budget for the year 2015",
                        Status = "Draft",
                        fkCostModelGroup = 2
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