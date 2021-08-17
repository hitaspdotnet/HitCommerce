namespace Hitasp.HitCommerce.Tax
{
    public static class TaxDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Tax";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Tax";
    }
}
