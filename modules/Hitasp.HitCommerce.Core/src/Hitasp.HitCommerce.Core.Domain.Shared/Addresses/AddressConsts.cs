namespace Hitasp.HitCommerce.Core.Addresses
{
    public static class AddressConsts
    {
        private const string DefaultSorting = "{0}ContactName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Address." : string.Empty);
        }

        public const int ContactNameMaxLength = 450;
        public const int PhoneMaxLength = 450;
        public const int AddressLine1MaxLength = 450;
        public const int AddressLine2MaxLength = 450;
        public const int ZipOrPostalCodeMaxLength = 450;
    }
}