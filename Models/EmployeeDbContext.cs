using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationChart.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        { }

        public DbSet<XHR_Job_History> Job_history { get; set; }
        public DbSet<NameChildObject> table { get; set; }
        public DbSet<Users> rootusers { get; set; }
        public DbSet<Employees> employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<XHR_Job_History>().ToTable("XHR_Job_History");

            modelBuilder.Entity<Users>(eb =>{ 
                eb.HasNoKey();
            });
            modelBuilder.Entity<Employees>(eb => {
                eb.HasNoKey();
            });
        }
    }

}
