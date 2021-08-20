using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScrewIt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Repositories
{
    public class ScrewItDbContext : IdentityDbContext<ApplicationUser>
    {

        public ScrewItDbContext(DbContextOptions<ScrewItDbContext> options) : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ReceiptProduct>()
                .HasOne(r => r.Receipt)
                .WithMany(rp => rp.ReceiptProducts)
                .HasForeignKey(ri => ri.ReceiptId);

            builder.Entity<ReceiptProduct>()
                .HasOne(r => r.Product)
                .WithMany(rp => rp.ReceiptProducts)
                .HasForeignKey(ri => ri.ProductId);

            builder.Entity<ReceiptService>()
               .HasOne(r => r.Receipt)
               .WithMany(rp => rp.ReceiptServices)
               .HasForeignKey(ri => ri.ReceiptId);

            builder.Entity<ReceiptService>()
                .HasOne(r => r.Service)
                .WithMany(rp => rp.ReceiptServices)
                .HasForeignKey(ri => ri.ServiceId);

        }

        public DbSet<Dimension> Dimensions { get; set; }
         
        public DbSet<Order> Orders { get; set; }

        public DbSet<Panel> Panels { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<ReceiptProduct> ReceiptProducts { get; set; }

        public DbSet<ReceiptService> ReceiptServices { get; set; }

        public DbSet<ReceiptItem> ReceiptItems { get; set; }
    }
}
