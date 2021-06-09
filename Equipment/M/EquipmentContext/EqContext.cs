using Equipment.M.EquipmentContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using OKB3Admin;
using OKB3Admin.Connection;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipment.M.EquipmentContext 
{
    public class EqContext : DbContext
    {
        public DbSet<Account_M> Account { get; set; }

        public DbSet<Komplekt_M> Komplekt { get; set; }
        public DbSet<MB_K_M> Motherboards_K { get; set; }
        public DbSet<MB_M> Motherboards { get; set; }
        public DbSet<Ports_M> Ports { get; set; }
        public DbSet<Ram_type_M> Ram_type { get; set; }
        public DbSet<Status_M> Status { get; set; }
        public DbSet<Type_eq_M> Type_equipment { get; set; }
        public DbSet<Monitor_M> Monitor { get; set; }
        public DbSet<Chipset_M> Chipset { get; set; }
        public DbSet<Socket_M> Socket { get; set; }
        public DbSet<Inventory_m> Inventory { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql($"server = {ConectionSetting.GetServer()}; database = {ConectionSetting.GetDb(DbType.app)}; uid = root; pwd = root",
                new MySqlServerVersion(new Version(5, 5, 5)));
            optionsBuilder.EnableSensitiveDataLogging(true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Socket_M>().HasKey(x => x.GID);

            modelBuilder.Entity<Chipset_M>().HasKey(x => x.GID);

            modelBuilder.Entity<Komplekt_M>().HasKey(x => x.GID);

            modelBuilder.Entity<MB_K_M>().HasKey(x => x.Id);

            modelBuilder.Entity<MB_M>().HasKey(x => x.GID);

            modelBuilder.Entity<Monitor_M>().HasKey(x => x.GID);

            modelBuilder.Entity<Ports_M>().HasKey(x => x.Id);

            modelBuilder.Entity<Ram_type_M>().HasKey(x => x.GID);

            modelBuilder.Entity<Status_M>().HasKey(x => x.GID);

            modelBuilder.Entity<Type_eq_M>().HasKey(x => x.GID);

            modelBuilder.Entity<Inventory_m>().HasKey(x => x.Id);
        }
    }
}
