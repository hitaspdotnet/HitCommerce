namespace Hitasp.HitCommerce.Pricing
{
    public static class PricingDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Pricing";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Pricing";
    }
}
