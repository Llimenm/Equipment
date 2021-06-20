using Microsoft.EntityFrameworkCore;
using OKB3Admin.Connection;
using System;

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
