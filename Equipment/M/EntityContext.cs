using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using OKB3Admin;
using OKB3Admin.M;
using OKB3Admin.M.Structura;
using OKB3Admin.M.InventorySystem;
using OKB3Admin.Connection;

namespace Equipment.M
{
    public class EntityContext : MainAppContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql($"server = {ConectionSetting.GetServer()}; database = {ConectionSetting.GetDb(DbType.main)}; uid = root; pwd = root",
                new MySqlServerVersion(new Version(5, 5, 5)));
            optionsBuilder.EnableSensitiveDataLogging(true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
