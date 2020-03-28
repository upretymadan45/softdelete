using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder builder){

            base.OnModelCreating(builder);
        }


        public override int SaveChanges(){

            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity;

                if(entry.State == EntityState.Deleted && entity is ISoftDelete){
                    entry.State = EntityState.Modified;

                    entity.GetType().GetProperty("RecStatus").SetValue(entity,'D');
                }
            }

            return base.SaveChanges();
        }
    }
}
