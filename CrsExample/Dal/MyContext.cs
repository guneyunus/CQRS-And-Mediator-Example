using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CqrsExample.Entitiy;
using Microsoft.EntityFrameworkCore;

namespace CqrsExample.Dal
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options):base(options)
        {
            

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasKey(x => x.Id);
        }
    }
}
