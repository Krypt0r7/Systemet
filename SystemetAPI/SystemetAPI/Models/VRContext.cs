using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;

namespace SystemetAPI.Models
{
    public partial class VRContext : DbContext
    { 
        public VRContext(DbContextOptions<VRContext> options)
            : base(options)
        {
        }

        public DbSet<SysSortTable> SysSortTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(local)\\SQLEXPRESS;Initial Catalog=Systemet;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
