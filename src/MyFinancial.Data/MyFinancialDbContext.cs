using Microsoft.EntityFrameworkCore;
using MyFinancial.Data.Entities;

namespace MyFinancial.Data
{
    public class MyFinancialDbContext : DbContext
    {
        public DbSet<Competence>? Competences { get; set; }
        public DbSet<Input>? Inputs { get; set; }
        public DbSet<Output>? Outputs { get; set; }

        public MyFinancialDbContext(DbContextOptions<MyFinancialDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competence>(x =>
            {
                x.HasKey(s => s.Id);
            });

            modelBuilder.Entity<Input>(x =>
            {
                x.HasKey(s => s.Id);

                x.HasOne(s => s.Competence)
                    .WithMany(s => s.Inputs)
                    .HasForeignKey(s => s.CompetenceId);
            });

            modelBuilder.Entity<Output>(x =>
            {
                x.HasKey(s => s.Id);

                x.HasOne(s => s.Competence)
                    .WithMany(s => s.Outputs)
                    .HasForeignKey(s => s.CompetenceId);
            });
        }
    }
}
