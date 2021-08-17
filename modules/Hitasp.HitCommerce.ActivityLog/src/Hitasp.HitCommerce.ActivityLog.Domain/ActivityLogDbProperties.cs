namespace Hitasp.HitCommerce.ActivityLog
{
    public static class ActivityLogDbProperties
    {
        public static string DbTablePrefix { get; set; } = "ActivityLog";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "ActivityLog";
    }
}
