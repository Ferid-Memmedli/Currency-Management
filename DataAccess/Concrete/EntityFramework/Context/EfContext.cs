using Entities.Concrete;
using Entities.EfCodeFirstMappings;
using System.Data.Entity;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class EfContext : DbContext
    {
        public EfContext() : base("EfContext")
        {

        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
