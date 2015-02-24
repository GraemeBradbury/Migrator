using System.Diagnostics;
using System.Reflection;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors.SqlServer;
using System.Linq;

namespace Migrator
{
    public static class Runner
    {
        public static void MigrateToLatest(string connectionString)
        {
            var runner = CreateMigrationRunner(connectionString);
            runner.MigrateUp(true);
        }

        public static void BringDownToInitial(string connectionString)
        {
            var runner = CreateMigrationRunner(connectionString);
            runner.MigrateDown(0);
        }

        private static MigrationRunner CreateMigrationRunner(string connectionString)
        {
            var announcer = new TextWriterAnnouncer(s => Debug.WriteLine(s));
            var assembly = Assembly.GetExecutingAssembly();

            var migrationContext = new RunnerContext(announcer)
            {
                Namespace = "Migrator.Migrations"
            };

            var options = new MigrationOptions {PreviewOnly = false, Timeout = 60};
            var factory = new SqlServer2008ProcessorFactory();
            var processor = factory.Create(connectionString, announcer, options);
            var runner = new MigrationRunner(assembly, migrationContext, processor);
            return runner;
        }

        public class MigrationOptions : IMigrationProcessorOptions
        {
            public bool PreviewOnly { get; set; }
            public string ProviderSwitches { get; set; }
            public int Timeout { get; set; }
        }
    }
}