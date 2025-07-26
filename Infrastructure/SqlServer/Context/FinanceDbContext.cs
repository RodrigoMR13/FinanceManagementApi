using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Context
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> option) : base(option) { }

        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("TransactionTypes");

                entity.HasKey(tt => tt.Id);
                entity.Property(tt => tt.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(tt => tt.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transactions");

                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id)
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(t => t.Value)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(e => e.DateTime)
                  .HasColumnType("timestamp")
                  .IsRequired();

            });
        }
    }
}
