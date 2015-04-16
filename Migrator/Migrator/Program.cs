namespace Migrator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string connection =
                @"Data Source=CONCORDE-DEV\Corecontrol;Initial Catalog=Cust2;User Id=dev;Password=password;";

            if (args.Length > 0 && args[0].ToLowerInvariant() == "up")
            {
                Runner.MigrateToLatest(connection);
            }
            else if (args.Length > 0 && args[0].ToLowerInvariant() == "down")
            {
                Runner.BringDownToInitial(connection);
            }
            else
            {
                Runner.BringDownToInitial(connection);

                Runner.MigrateToLatest(connection);
            }
        }
    }
}