using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletItem> WalletItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
