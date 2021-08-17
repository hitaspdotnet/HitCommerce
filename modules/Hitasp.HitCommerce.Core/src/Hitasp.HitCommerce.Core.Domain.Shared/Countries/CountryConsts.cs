namespace Hitasp.HitCommerce.Core.Countries
{
    public static class CountryConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Country." : string.Empty);
        }

        public const int NameMaxLength = 450;
        public const int Code3MaxLength = 3;
    }
}