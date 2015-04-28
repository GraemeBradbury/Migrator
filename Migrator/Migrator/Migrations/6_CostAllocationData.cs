using System;
using FluentMigrator;
using FluentMigrator.Runner.Extensions;

namespace Migrator.Migrations
{
    [Migration(6)]
    public class CostAllocationData : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("tblCostComponent")
                  .WithIdentityInsert()
                  .Row(new {Id = 1, ReferenceNumber = 1, Description = "Licence & Subscription Costs"})
                  .Row(new {Id = 2, ReferenceNumber = 2, Description = "Installation and Setup"})
                  .Row(new {Id = 3, ReferenceNumber = 3, Description = "Customization and Integration"})
                  .Row(new {Id = 4, ReferenceNumber = 4, Description = "Data Migration"})
                  .Row(new {Id = 5, ReferenceNumber = 5, Description = "Training"})
                  .Row(new {Id = 6, ReferenceNumber = 6, Description = "Maintenance and Support"})
                  .Row(new {Id = 7, ReferenceNumber = 7, Description = "Hardware"})
                  .Row(new {Id = 8, ReferenceNumber = 8, Description = "Networking"})
                  .Row(new {Id = 9, ReferenceNumber = 9, Description = "Decommissioning"})
                  .Row(new {Id = 10, ReferenceNumber = 10, Description = "Other Costs"})
                  .Row(new {Id = 11, ReferenceNumber = 11, Description = "Additional Staff Costs"})
                  .Row(new {Id = 12, ReferenceNumber = 12, Description = "Intangible Costs"});

            Insert.IntoTable("tblCostComponentAllocation")
                  .Row(new {Version = 1, fkCostModel = 1, fkCostComponent = 1, Allocation = 39, Weighting = 6.88})
                  .Row(new { Version = 1, fkCostModel = 1, fkCostComponent = 2, Allocation = 2, Weighting = 0.35 })
                  .Row(new { Version = 1, fkCostModel = 1, fkCostComponent = 3, Allocation = 74, Weighting = 13.05 })
                  .Row(new { Version = 1, fkCostModel = 1, fkCostComponent = 4, Allocation = 79, Weighting = 13.93 })
                  .Row(new { Version = 1, fkCostModel = 1, fkCostComponent = 5, Allocation = 73, Weighting = 12.87 })
                  .Row(new { Version = 1, fkCostModel = 1, fkCostComponent = 6, Allocation = 79, Weighting = 13.93 })
                  .Row(new { Version = 1, fkCostModel = 1, fkCostComponent = 7, Allocation = 99, Weighting = 17.46 })
                  .Row(new { Version = 1, fkCostModel = 1, fkCostComponent = 8, Allocation = 79, Weighting = 13.93 })
                  .Row(new { Version = 1, fkCostModel = 1, fkCostComponent = 9, Allocation = 88, Weighting = 15.52 })
                  .Row(new { Version = 1, fkCostModel = 1, fkCostComponent = 10, Allocation = 55, Weighting = 9.70 })
                  .Row(new { Version = 1, fkCostModel = 1, fkCostComponent = 11, Allocation = 3, Weighting = 0.53 })
                  .Row(new { Version = 1, fkCostModel = 1, fkCostComponent = 12, Allocation = 48, Weighting = 8.55 });

            Insert.IntoTable("tblCostComponentAllocation")
                  .Row(new { Version = 1, fkCostModel = 2, fkCostComponent = 1, Allocation = 58, Weighting = 10.50 })
                  .Row(new { Version = 1, fkCostModel = 2, fkCostComponent = 2, Allocation = 6, Weighting = 10.97 })
                  .Row(new { Version = 1, fkCostModel = 2, fkCostComponent = 3, Allocation = 12, Weighting = 2.19 })
                  .Row(new { Version = 1, fkCostModel = 2, fkCostComponent = 4, Allocation = 73, Weighting = 13.35 })
                  .Row(new { Version = 1, fkCostModel = 2, fkCostComponent = 5, Allocation = 82, Weighting = 14.99 })
                  .Row(new { Version = 1, fkCostModel = 2, fkCostComponent = 6, Allocation = 64, Weighting = 11.70 })
                  .Row(new { Version = 1, fkCostModel = 2, fkCostComponent = 7, Allocation = 29, Weighting = 5.30 })
                  .Row(new { Version = 1, fkCostModel = 2, fkCostComponent = 8, Allocation = 49, Weighting = 8.96 })
                  .Row(new { Version = 1, fkCostModel = 2, fkCostComponent = 9, Allocation = 8, Weighting = 1.46 })
                  .Row(new { Version = 1, fkCostModel = 2, fkCostComponent = 10, Allocation = 29, Weighting = 5.30 })
                  .Row(new { Version = 1, fkCostModel = 2, fkCostComponent = 11, Allocation = 37, Weighting = 6.76 })
                  .Row(new { Version = 1, fkCostModel = 2, fkCostComponent = 12, Allocation = 100, Weighting = 18.28 });

            Update.Table("tblCostModel").Set(new {Allocation = 567}).Where(new {Id = 1});
            Update.Table("tblCostModel").Set(new {Allocation = 547}).Where(new {Id = 2});
        }

        public override void Down()
        {
            Delete.FromTable("tblCostComponentAllocation").AllRows();
            Delete.FromTable("tblCostComponent").AllRows();

            Update.Table("tblCostModel").Set(new { Allocation = 0 }).Where(new { Id = 1 });
            Update.Table("tblCostModel").Set(new { Allocation = 0 }).Where(new { Id = 2 });
        }
    }
}