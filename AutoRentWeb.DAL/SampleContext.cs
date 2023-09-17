using AutoRentWeb.DAL.Context;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRentWeb.DAL.Constants;

namespace AutoRentWeb.DAL
{
    public class SampleContext : IDesignTimeDbContextFactory<AutoRentDbContext>
    {
        public AutoRentDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AutoRentDbContext>();

            // получаем конфигурацию из файла appsettings.json
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile(DbConstants.AppSettingsFileName);
            IConfigurationRoot config = builder.Build();
            // получаем строку подключения из файла appsettings.json
            string connectionString = config.GetConnectionString(DbConstants.ConnectionStringName);
            optionsBuilder.UseSqlServer(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new AutoRentDbContext(optionsBuilder.Options);
        }
    }
}
