using Microsoft.EntityFrameworkCore;
using ScrewIt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Repositories
{
    public class ScrewItDbContext : DbContext
    {

        public ScrewItDbContext(DbContextOptions<ScrewItDbContext> options) : base (options)
        {
        }

        public DbSet<Dimension> Dimensions { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
