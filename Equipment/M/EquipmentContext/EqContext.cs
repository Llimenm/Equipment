using Equipment.M.EquipmentContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Equipment.M.EquipmentContext 
{
    public class EqContext : DbContext
    {
        public DbSet<Account_M> Account { get; set; }
        public DbSet<Chipset_M> Chipset { get; set; }
        public DbSet<Komplekt_M> Komplekt { get; set; }
        public DbSet<MB_K_M> Motherboards_K { get; set; }
        public DbSet<MB_M> Motherboards { get; set; }
        public DbSet<Ports_M> Ports { get; set; }
        public DbSet<Ram_type_M> Ram_type{ get; set; }
        public DbSet<Socket_M> Socket { get; set; }
        public DbSet<Status_M> Status { get; set; }
        public DbSet<Type_eq_M> Type_equipment{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server = localhost; database = Eq_test; uid = root; pwd = root",
                new MySqlServerVersion(new Version(5, 5, 5)));
            optionsBuilder.EnableSensitiveDataLogging(true);
        }
    }
}
