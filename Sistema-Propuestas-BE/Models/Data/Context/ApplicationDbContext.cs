using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Propuesta> Propuestas { get; set; }

        public DbSet<Revisor> Revisores { get; set; }
    }
}
