namespace Hitasp.HitCommerce.Core.Districts
{
    public static class DistrictConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "District." : string.Empty);
        }

        public const int NameMaxLength = 450;
        public const int TypeMaxLength = 450;
    }
}