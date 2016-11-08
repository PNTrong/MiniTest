using Model.Models;
using System.Data.Entity;

namespace Data
{
    public class SDCTestDbContext : DbContext
    {
        public SDCTestDbContext() : base("SDCTestConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Employee> Employees { set; get; }
        public DbSet<County> Counties { set; get; }
        public DbSet<Province> Provinces { set; get; }
        public DbSet<Error> Errors { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
        }
    }
}