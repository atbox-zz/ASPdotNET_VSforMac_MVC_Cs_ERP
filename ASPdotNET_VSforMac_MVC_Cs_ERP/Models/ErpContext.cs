using System;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Models
{
    public class ErpContext : DbContext
    {
        public ErpContext(DbContextOptions<ErpContext> options)
            : base(options)
        {
        }

        public DbSet<Title> Titles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Custom> Customs { get; set; }
        public DbSet<Deliver> Delivers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Product_item> Product_items { get; set; }
        public DbSet<Product_data> Product_datas { get; set; }
        public DbSet<Order_master> Order_masters { get; set; }
        public DbSet<Order_detail> Order_details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
