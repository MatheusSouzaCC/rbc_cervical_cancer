using Microsoft.EntityFrameworkCore;
using Rbc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rbc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Caso> Casos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Caso>().ToTable("caso");

            base.OnModelCreating(builder);
        }
    }
}
