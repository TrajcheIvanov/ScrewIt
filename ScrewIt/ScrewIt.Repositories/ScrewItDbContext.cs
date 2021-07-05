using Microsoft.EntityFrameworkCore;
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
    }
}
