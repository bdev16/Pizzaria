using Microsoft.EntityFrameworkCore;

namespace Pizzaria.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {       
        }

    }
}
