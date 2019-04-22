using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace XFStarterKit.Core.SQLite
{
    public class XFStarterKitContext : DbContext
    {
        public XFStarterKitContext()
        {
            this.Database.EnsureCreated();
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IDatabaseService>().GetDatabasePath();
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
