using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using OKB3Admin;
using OKB3Admin.M;


namespace Equipment.M
{
    public class EntityContext : DbContext
    {
     

        public DbSet<Korpus_M> Korpus { get; set; }
        public DbSet<Podrazdelenie_M> Podrazdelenies { get; set; }
        public DbSet<Otdelenie_M> Otdelenie { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql($"server = {ConectionSetting.GetServer()}; database = {ConectionSetting.GetDb(DbType.main)}; uid = root; pwd = root",
                new MySqlServerVersion(new Version(5, 5, 5)));
            optionsBuilder.EnableSensitiveDataLogging(true);
        }
    }
}
