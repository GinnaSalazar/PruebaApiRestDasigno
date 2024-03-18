using Microsoft.EntityFrameworkCore;
using Modelo_Dasigno.Entities;

namespace Modelo_Dasigno.Context
{
    public class DasignoDbContext : DbContext
    {
        public DasignoDbContext(DbContextOptions<DasignoDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
