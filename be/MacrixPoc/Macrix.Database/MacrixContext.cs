
using MacrixPoc;
using MacrixPoc.User.Model;
using Microsoft.EntityFrameworkCore;

namespace Macrix.Database
{
    public class MacrixContext : DbContext
    {
        public MacrixContext(DbContextOptions<MacrixContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<User> Users { get; set; }
    }
}