using System.Data.Entity;
using Lab5Mzl.Models;

namespace Lab5Mzl.DAL
{
    public class StoreContext: DbContext
    {
        public StoreContext()
            : base("StoreContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("store");
            base.OnModelCreating(modelBuilder);
        }
    }
}