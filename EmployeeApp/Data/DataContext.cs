using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Pluralization
            builder.Entity<Employee>().ToTable("Employee");
            builder.Entity<OrganizationUnit>().ToTable("OrganizationUnit");

            // Self Referenced Contrains
            builder.Entity<Employee>()
                .HasOne(e => e.Superior)
                .WithMany(e => e.Subaltern)
                .HasForeignKey(e => e.SuperiorId);

            // Unique Contrains
            builder.Entity<Employee>()
                .HasIndex(e => e.Identification)
                .IsUnique();
        }
    }
}
