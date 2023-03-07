using Microsoft.EntityFrameworkCore;
using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.DAL
{
    public class OrderDbContext:DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderWindow> OrderWindows { set; get; }
        public DbSet<OrderWindowDetail> OrderWindowDetails { set; get; }
    }
}
