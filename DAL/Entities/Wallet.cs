using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Wallet : BaseItem
    {
        public Guid UserId { get; set; }
        public User User { get; set; }


        public ICollection<Transaction> Transaction { get; set; }
        public IEnumerable<WalletItem> WalletItems { get; set; }
    }
}
