using DAL.TestTaskApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TestTaskApi.DAL.EF
{
    public class TestTaskContext : DbContext
    {
        public TestTaskContext(DbContextOptions<TestTaskContext> options) : base(options) { }

        private readonly static ValueConverter<DateTime?, DateTime?> _dateWithNullConverter = new(
            d => d != null ? DateTime.SpecifyKind(d.Value, DateTimeKind.Utc) : null,
            d => d);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>(Bet);
            modelBuilder.Entity<Transaction>(Transaction);
            modelBuilder.Entity<Player>(Player);
        }

        public void Bet(EntityTypeBuilder<Bet> builder)
        {
            builder.Property(u => u.ChangeDate).HasConversion(_dateWithNullConverter);
            builder.Property(u => u.SettlementDate).HasConversion(_dateWithNullConverter);
        }

        public void Transaction(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(u => u.ChangeDate).HasConversion(_dateWithNullConverter);
        }

        public void Player(EntityTypeBuilder<Player> builder)
        {
            builder.Property(u => u.RegistrationDate).HasConversion(_dateWithNullConverter);     
        }
    }
}
