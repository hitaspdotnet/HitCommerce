namespace Hitasp.HitCommerce.Core.StateOrProvinces
{
    public static class StateOrProvinceConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "StateOrProvince." : string.Empty);
        }

        public const int NameMaxLength = 450;
        public const int Code3MinLength = 3;
        public const int Code3MaxLength = 3;
        public const int TypeMaxLength = 450;
    }
}