using EntityFrameworkDemo.Dominio.Entities.DespesaModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace EntityFrameworkDemo.Infra
{
    public class FinancaDbContext : DbContext
    {
        public DbSet<Despesa> Despesas { get; set; }

        private static ILoggerFactory loggerFactorySeq = LoggerFactory.Create(x => x.AddSerilog());

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(loggerFactorySeq)
                .UseSqlServer(@"Data Source=(localdb)\MSSqlLocalDB;Initial Catalog=DB_EntityFrameworkDemo;Integrated Security=True;Pooling=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinancaDbContext).Assembly);
        }
    }
}
