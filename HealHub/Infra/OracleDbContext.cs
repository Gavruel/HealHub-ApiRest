using HealHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealHub.Infra
{
    public class OracleDbContext : DbContext
    {
        public DbSet <User> Users { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Prognosis> Prognosis { get; set; }
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {

        }
    }
}
