using Microsoft.EntityFrameworkCore;
using ApiAchei.Models;

namespace ApiAchei.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Models.Attribute> Attributes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configuração para não apagar produtos ao remover categoria
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            // Configuração para apagar atributos quando produto for removido
            modelBuilder.Entity<Models.Attribute>()
                .HasOne(a => a.Product)
                .WithMany(p => p.Attributes)
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
