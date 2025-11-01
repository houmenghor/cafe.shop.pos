namespace CafeShopManagement.Utils
{
    /// <summary>
    /// Central branding for the POS (used by receipts/UI).
    /// </summary>
    public static class PosBrand
    {
        public static string ShopName = "Cafe Shop";
        public static string BranchOrAddress = "RUPP";
        public static string BranchCode = "RUPP";      // used for building ReceiptNo like RUPP-00042
        public static string? LogoPath = null;         // e.g., @"C:\assets\cafe-shop-logo.png"
    }
}
