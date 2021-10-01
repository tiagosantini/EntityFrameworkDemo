using EntityFrameworkDemo.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkDemo.Infra
{
    public class FinancaDbContext : DbContext
    {
        public DbSet<Despesa> Despesas { get; set; }

        private static ILoggerFactory loggerFactoryDebug = LoggerFactory.Create(x => x.AddDebug());

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(loggerFactoryDebug)
                .UseSqlServer(@"Data Source=(localdb)\MSSqlLocalDB;Initial Catalog=DB_EntityFrameworkDemo;Integrated Security=True;Pooling=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinancaDbContext).Assembly);
        }
    }
}
