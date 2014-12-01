using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class CapstoneDb : DbContext
    {
        public CapstoneDb()
            : base("name=CapstoneDb")
        {
        }
        // No dependent on foreign keys
        public DbSet<ServiceArea> ServiceAreas { get; set; }
        public DbSet<Project> Projects { get; set; }
        //public DbSet<Credential> Credentials { get; set; }

        // Dependent on foreign keys
        public DbSet<User> Users { get; set; }
        public DbSet<DetailedService> DetailedServices { get; set; }
        //public DbSet<UserCredential> UserCredentials { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherEvent> VoucherEvents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voucher>()
                .HasRequired(d => d.DetailedService)
                .WithMany()
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}