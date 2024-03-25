using Microsoft.EntityFrameworkCore;
using MyBGList.Models;

namespace MyBGList_Chap6.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Packet> Packets { get; set; }
        public DbSet<BakingGood> BakingGoods { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<OrderBakingGood> OrderContents { get; set; }
        public DbSet<BakingGoodBatch> BakingGoodBatches { get; set; }
        public DbSet<BatchStock> BatchDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<Packet>()
                .HasKey(p => p.PacketId);

            modelBuilder.Entity<BakingGood>()
                .HasKey(bg => bg.BakingGoodId);

            modelBuilder.Entity<Batch>()
                .HasKey(b => b.BatchId);

            modelBuilder.Entity<Stock>()
                .HasKey(s => s.StockId);

            modelBuilder.Entity<OrderBakingGood>()
                .HasKey(oc => new { oc.OrderId, oc.BakingGoodId });

            modelBuilder.Entity<BakingGoodBatch>()
                .HasKey(bg => new { bg.BatchId, bg.BakingGoodId });

            modelBuilder.Entity<BatchStock>()
                .HasKey(bd => new { bd.BatchId, bd.StockId });

            // Define relationships

            modelBuilder.Entity<Packet>()
                .HasOne(p => p.Order)
                .WithMany(o => o.Packets)
                .HasForeignKey(p => p.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderBakingGood>()
                .HasOne(oc => oc.Order)
                .WithMany(o => o.OrderBakingGoods)
                .HasForeignKey(oc => oc.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderBakingGood>()
                .HasOne(oc => oc.BakingGood)
                .WithMany()
                .HasForeignKey(oc => oc.BakingGoodId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BakingGoodBatch>()
                .HasOne(bg => bg.Batch)
                .WithMany(b => b.BakingGoodBatches)
                .HasForeignKey(bg => bg.BatchId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BakingGoodBatch>()
                .HasOne(bg => bg.BakingGood)
                .WithMany()
                .HasForeignKey(bg => bg.BakingGoodId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BatchStock>()
                .HasOne(bd => bd.Batch)
                .WithMany(b => b.BatchStocks)
                .HasForeignKey(bd => bd.BatchId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BatchStock>()
                .HasOne(bd => bd.Stock)
                .WithMany()
                .HasForeignKey(bd => bd.StockId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
