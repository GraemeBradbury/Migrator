#r FluentMigrator.Runner.dll
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Announcers;
using FluentMigrator;
using System;
using System.Reflection;

public static class Runner
{
    public class MigrationOptions : IMigrationProcessorOptions
    {
        public bool PreviewOnly { get; set; }
        public string ProviderSwitches { get; set; }
        public int Timeout { get; set; }
    }


    public static void MigrateToLatest(string connectionString){
      var runner = CreateMigrationRunner(connectionString);
      runner.MigrateUp(true);
    }

    public static void BringDownToStart(string connectionString){
      var runner = CreateMigrationRunner(connectionString);
      runner.MigrateDown(0);
    }

    private static MigrationRunner CreateMigrationRunner(string connectionString)
    {
        var announcer = new TextWriterAnnouncer(s => System.Diagnostics.Debug.WriteLine(s));
        var assembly = Assembly.GetExecutingAssembly();

        var migrationContext = new RunnerContext(announcer)
        {
        };

        var options = new MigrationOptions { PreviewOnly=false, Timeout=60 };
        var factory = new FluentMigrator.Runner.Processors.SqlServer.SqlServer2008ProcessorFactory();
        var processor = factory.Create(connectionString, announcer, options);
        var runner = new MigrationRunner(assembly, migrationContext, processor);
        return runner;
    }
}
