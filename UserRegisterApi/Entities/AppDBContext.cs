using Microsoft.EntityFrameworkCore;
using UserRegisterApi.Entities.Data;

namespace UserRegisterApi.Entities
{
    public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
    {
        public DbSet<User> User { get; set; }
    }
}
