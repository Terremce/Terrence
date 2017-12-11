using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Terrence.Domain;

namespace Terrence.DataMapping
{
    public partial class DataBaseContext : DbContext
    {

        public DataBaseContext()
            : base("Name=MyDB")
        {
            Database.SetInitializer<DataBaseContext>(null);
        }

        public DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DriverMap());
        }
    }
}
