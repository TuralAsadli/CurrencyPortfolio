using DAL.Entities;

namespace CurrencyApi.DTOs.WalletItems
{
    public class WalletItemDTO
    {
        public float BuyPrice { get; set; }
        public float Amount { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public string IconPath { get; set; }
        public Guid WalletId { get; set; }
        public Wallet Wallet { get; set; }
    }
}
