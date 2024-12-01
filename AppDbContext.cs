using DB_TEST.Migrations;
using System.Data.Entity;

namespace DB_TEST
{


   

    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext") // Connection string name in config
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure relationships and constraints (optional)
            modelBuilder.Entity<Product>()
                .HasRequired(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }



}
