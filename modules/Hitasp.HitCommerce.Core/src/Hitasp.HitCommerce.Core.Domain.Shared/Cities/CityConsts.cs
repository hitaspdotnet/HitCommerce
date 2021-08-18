namespace Hitasp.HitCommerce.Core.Cities
{
    public static class CityConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "City." : string.Empty);
        }

        public const int NameMaxLength = 450;
        public const int TypeMaxLength = 450;
    }
}